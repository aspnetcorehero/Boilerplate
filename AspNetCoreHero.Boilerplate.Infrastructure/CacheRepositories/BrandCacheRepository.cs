using AspNetCoreHero.Boilerplate.Application.DTOs.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories
{
    public class BrandCacheRepository : IBrandCacheRepository
    {
        public Task<Brand> GetByIdAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandDto>> GetCachedListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
