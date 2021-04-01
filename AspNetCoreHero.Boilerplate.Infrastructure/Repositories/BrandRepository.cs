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
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BrandRepository(ApplicationDbContext repositoryContext, IDistributedCache distributedCache)
            : base(repositoryContext)
        {
            _distributedCache = distributedCache;
        }

        public IQueryable<Brand> Brands => Entities;

        public async Task DeleteAsync(Brand brand)
        {
            await Delete(brand);
            await _distributedCache.RemoveAsync(CacheKeys.BrandCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.BrandCacheKeys.GetKey(brand.Id));
        }

        public async Task<Brand> GetByIdAsync(int brandId)
        {

            return await Entities.Where(p => p.Id == brandId).FirstOrDefaultAsync();
        }

        public async Task<List<Brand>> GetListAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Brand brand)
        {
            await Create(brand);
            await _distributedCache.RemoveAsync(CacheKeys.BrandCacheKeys.ListKey);
            return brand.Id;
        }

        public async Task UpdateAsync(Brand brand)
        {
            await UpdateAsync(brand);
            await _distributedCache.RemoveAsync(CacheKeys.BrandCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.BrandCacheKeys.GetKey(brand.Id));
        }
    }
}