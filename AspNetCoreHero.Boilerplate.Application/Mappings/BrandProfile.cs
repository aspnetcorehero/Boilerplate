using AspNetCoreHero.Boilerplate.Application.Features.Brands.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AutoMapper;

namespace AspNetCoreHero.Boilerplate.Application.Mappings
{
    class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}
