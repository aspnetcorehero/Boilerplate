using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Infrastructure.DbContexts;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _repositoryContext;
        private readonly IDistributedCache _distributedCache;
        private IBrandRepository _brandRepository;
        private IProductRepository _productRepository;

        public IBrandRepository Brand
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_repositoryContext, _distributedCache);
                }

                return _brandRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_repositoryContext, _distributedCache);
                }

                return _productRepository;
            }
        }

        public RepositoryWrapper(IDistributedCache distributedCache, ApplicationDbContext repositoryContext)
        {
            _distributedCache = distributedCache;
            _repositoryContext = repositoryContext;
        }

    }
}
