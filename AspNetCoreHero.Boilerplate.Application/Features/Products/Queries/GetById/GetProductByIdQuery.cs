using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Exceptions;
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Domain.Entities;
using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Result<Product>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<Product>>
        {
            private readonly IProductCacheService _productCache;

            public GetProductByIdQueryHandler(IProductCacheService productCache)
            {
                _productCache = productCache;
            }
            public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productCache.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                return Result<Product>.Success(product);
            }
        }
    }
}
