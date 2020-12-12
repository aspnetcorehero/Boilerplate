using AspNetCoreHero.Boilerplate.Application.Exceptions;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Result<Product>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<Product>>
        {
            private readonly IProductCacheRepository _productCache;

            public GetProductByIdQueryHandler(IProductCacheRepository productCache)
            {
                _productCache = productCache;
            }
            public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productCache.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                return Result<Product>.Success(product);
            }
        }
    }
}
