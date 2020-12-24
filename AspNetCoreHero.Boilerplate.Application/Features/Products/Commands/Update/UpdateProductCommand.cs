using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProductRepository _productRepository;

            public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
            {
                _productRepository = productRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(command.Id);

                if (product == null)
                {
                    return Result<int>.Fail($"Product Not Found.");
                }
                else
                {
                    product.Name = command.Name ?? product.Name;
                    product.Rate = (command.Rate == 0) ? product.Rate : command.Rate;
                    product.Description = command.Description ?? product.Description;
                    product.BrandId = (command.BrandId == 0) ? product.BrandId : command.BrandId;
                    await _productRepository.UpdateAsync(product);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(product.Id);
                }
            }
        }
    }
}