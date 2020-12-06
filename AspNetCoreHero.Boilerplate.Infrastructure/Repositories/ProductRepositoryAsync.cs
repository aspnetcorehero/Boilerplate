using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    class ProductRepositoryAsync : IProductRepositoryAsync
    {
        private readonly IRepositoryAsync<Product> _repository;
        private readonly IDistributedCache _distributedCache;

        public ProductRepositoryAsync(IDistributedCache distributedCache, IRepositoryAsync<Product> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Product> Products => _repository.Entities;

        public Task DeleteAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _repository.Entities.Where(p=> p.Id == productId).FirstOrDefaultAsync();
        }

        public Task<ProductDto> GetDetailsByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            var productList = await _repository.Entities.Select(d => new ProductDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Rate = d.Rate,
                Barcode = d.Barcode
            }).ToListAsync();

            return productList;
        }

        public Task<List<ProductDto>> GetSelectListAsync()
        {
            throw new System.NotImplementedException();
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
