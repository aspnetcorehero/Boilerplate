using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Result<int>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
            {
                _brandRepository = brandRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
            {
                var product = await _brandRepository.GetByIdAsync(command.Id);
                await _brandRepository.DeleteAsync(product);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(product.Id);
            }
        }
    }
}