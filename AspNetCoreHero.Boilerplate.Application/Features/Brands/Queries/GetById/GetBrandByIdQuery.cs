using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Brands.Queries.GetById
{
    public class GetBrandByIdQuery : IRequest<Result<GetBrandByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Result<GetBrandByIdResponse>>
        {
            private readonly IBrandCacheRepository _brandCache;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IBrandCacheRepository productCache, IMapper mapper)
            {
                _brandCache = productCache;
                _mapper = mapper;
            }

            public async Task<Result<GetBrandByIdResponse>> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _brandCache.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetBrandByIdResponse>(product);
                return Result<GetBrandByIdResponse>.Success(mappedProduct);
            }
        }
    }
}