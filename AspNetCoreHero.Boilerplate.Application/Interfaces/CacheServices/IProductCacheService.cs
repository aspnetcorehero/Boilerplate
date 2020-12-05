using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories
{
    public interface IProductCacheService
    {
        Task<List<ProductDto>> GetCachedListAsync();
    }
}
