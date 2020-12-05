using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories
{
    public class ProductCacheService : IProductCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IProductRepositoryAsync _productRepository;
        public ProductCacheService(IDistributedCache distributedCache, IProductRepositoryAsync productRepository)
        {
            _distributedCache = distributedCache;
            _productRepository = productRepository;
        }
        public async Task<List<ProductDto>> GetCachedListAsync()
        {
            string cacheKey = ProductCacheKeys.ListKey;
            var productList = await _distributedCache.GetAsync<List<ProductDto>>(cacheKey);
            if(productList == null)
            {
                productList = await _productRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, productList);
            }
            return productList;
        }
    }
}
