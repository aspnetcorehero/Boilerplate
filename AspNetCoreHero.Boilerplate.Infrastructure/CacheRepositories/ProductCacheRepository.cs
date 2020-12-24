using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories
{
    public class ProductCacheRepository : IProductCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IProductRepository _productRepository;

        public ProductCacheRepository(IDistributedCache distributedCache, IProductRepository productRepository)
        {
            _distributedCache = distributedCache;
            _productRepository = productRepository;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            string cacheKey = ProductCacheKeys.GetKey(productId);
            var product = await _distributedCache.GetAsync<Product>(cacheKey);
            if (product == null)
            {
                product = await _productRepository.GetByIdAsync(productId);
                Throw.Exception.IfNull(product, "Product", "No Product Found");
                await _distributedCache.SetAsync(cacheKey, product);
            }
            return product;
        }

        public async Task<List<Product>> GetCachedListAsync()
        {
            string cacheKey = ProductCacheKeys.ListKey;
            var productList = await _distributedCache.GetAsync<List<Product>>(cacheKey);
            if (productList == null)
            {
                productList = await _productRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, productList);
            }
            return productList;
        }
    }
}