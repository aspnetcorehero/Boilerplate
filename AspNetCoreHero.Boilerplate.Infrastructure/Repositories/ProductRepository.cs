using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly IDistributedCache _distributedCache;

        public ProductRepository(ApplicationDbContext repositoryContext, IDistributedCache distributedCache)
            : base(repositoryContext)
        {
            _distributedCache = distributedCache;
        }

        public IQueryable<Product> Products => Entities;

        public async Task DeleteAsync(Product product)
        {
            await Delete(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.GetKey(product.Id));
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await Entities.Where(p => p.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetListAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Product product)
        {
            await Create(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            return product.Id;
        }

        public async Task UpdateAsync(Product product)
        {
            await Update(product);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ProductCacheKeys.GetKey(product.Id));
        }
    }
}