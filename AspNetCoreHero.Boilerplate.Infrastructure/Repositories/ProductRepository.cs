using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryAsync<Product> _repository;
        private readonly IDistributedCache _distributedCache;

        public ProductRepository(IDistributedCache distributedCache, IRepositoryAsync<Product> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Product> Products => _repository.Entities;

        public async Task DeleteAsync(Product product)
        {
            await _repository.DeleteAsync(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.GetKey(product.Id));
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _repository.Entities.Where(p => p.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Product product)
        {
            await _repository.AddAsync(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            return product.Id;
        }

        public async Task UpdateAsync(Product product)
        {
            await _repository.UpdateAsync(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.GetKey(product.Id));
        }
    }
}