using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Create
{
    public partial class CreateProductCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }
        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _productRepository.InsertAsync(product);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(product.Id);
        }
    }
}
