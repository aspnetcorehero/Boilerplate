using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories
{
    public class BrandCacheRepository : IBrandCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IBrandRepository _brandRepository;
        public BrandCacheRepository(IDistributedCache distributedCache, IBrandRepository brandRepository)
        {
            _distributedCache = distributedCache;
            _brandRepository = brandRepository;
        }
        public Task<Brand> GetByIdAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Brand>> GetCachedListAsync()
        {
            string cacheKey = BrandCacheKeys.ListKey;
            var brandList = await _distributedCache.GetAsync<List<Brand>>(cacheKey);
            if (brandList == null)
            {
                brandList = await _brandRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, brandList);
            }
            return brandList;
        }
    }
}
