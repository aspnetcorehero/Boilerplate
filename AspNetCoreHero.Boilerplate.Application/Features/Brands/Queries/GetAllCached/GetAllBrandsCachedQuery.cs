using AspNetCoreHero.Boilerplate.Application.DTOs.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Brands.Queries.GetAllCached
{
    public class GetAllBrandsCachedQuery : IRequest<Result<List<BrandDto>>>
    {
        public GetAllBrandsCachedQuery()
        {

        }
    }

    public class GetAllBrandsCachedQueryHandler : IRequestHandler<GetAllBrandsCachedQuery, Result<List<BrandDto>>>
    {
        private readonly IBrandCacheRepository _productCache;

        public GetAllBrandsCachedQueryHandler(IBrandCacheRepository productCache)
        {
            _productCache = productCache;
        }

        public async Task<Result<List<BrandDto>>> Handle(GetAllBrandsCachedQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _productCache.GetCachedListAsync();
            return Result<List<BrandDto>>.Success(brandList);
        }
    }
}
