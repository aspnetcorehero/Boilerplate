using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateBrandCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IBrandRepository _brandRepository;

            public UpdateProductCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
            {
                _brandRepository = brandRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
            {
                var brand = await _brandRepository.GetByIdAsync(command.Id);

                if (brand == null)
                {
                    return Result<int>.Fail($"Brand Not Found.");
                }
                else
                {
                    brand.Name = command.Name ?? brand.Name;
                    brand.Tax = (command.Tax == 0) ? brand.Tax : command.Tax;
                    brand.Description = command.Description ?? brand.Description;
                    await _brandRepository.UpdateAsync(brand);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(brand.Id);
                }
            }
        }
    }
}