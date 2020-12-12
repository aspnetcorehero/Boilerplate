using AspNetCoreHero.Boilerplate.Application.DTOs.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached
{
    public class GetAllProductsCachedQuery : IRequest<Result<List<ProductDto>>>
    {
        public GetAllProductsCachedQuery()
        {

        }
    }

    public class GetAllProductsCachedQueryHandler : IRequestHandler<GetAllProductsCachedQuery, Result<List<ProductDto>>>
    {
        private readonly IProductCacheRepository _productCache;

        public GetAllProductsCachedQueryHandler(IProductCacheRepository productCache)
        {
            _productCache = productCache;
        }

        public async Task<Result<List<ProductDto>>> Handle(GetAllProductsCachedQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productCache.GetCachedListAsync();
            return Result<List<ProductDto>>.Success(productList);
        }
    }
}
