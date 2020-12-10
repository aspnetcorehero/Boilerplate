using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories
{
    public interface IProductCacheRepository
    {
        Task<List<ProductDto>> GetCachedListAsync();
        Task<Product> GetByIdAsync(int productId);
    }
}
