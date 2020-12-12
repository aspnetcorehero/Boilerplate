using AspNetCoreHero.Boilerplate.Application.DTOs.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public IQueryable<Brand> Brands => throw new NotImplementedException();

        public Task<List<BrandDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
