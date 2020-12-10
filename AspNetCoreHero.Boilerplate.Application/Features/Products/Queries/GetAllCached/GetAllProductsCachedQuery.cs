using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached
{
    public class GetAllProductsCachedQuery : IRequest<List<ProductDto>>
    {
        public GetAllProductsCachedQuery()
        {

        }
    }

    public class GetAllProductsCachedQueryHandler : IRequestHandler<GetAllProductsCachedQuery, List<ProductDto>>
    {
        private readonly IProductCacheRepository _productCache;

        public GetAllProductsCachedQueryHandler(IProductCacheRepository productCache)
        {
            _productCache = productCache;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsCachedQuery request, CancellationToken cancellationToken)
        {
            return await _productCache.GetCachedListAsync();
        }
    }
}
