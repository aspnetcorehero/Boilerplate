using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand> _repository;
        private readonly IDistributedCache _distributedCache;

        public BrandRepository(IDistributedCache distributedCache, IRepositoryAsync<Brand> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Brand> Brands => _repository.Entities;

        public async Task<List<Brand>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }
    }
}
