using AspNetCoreHero.Boilerplate.Application.DTOs.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using AutoMapper;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Mappings
{
    class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandDto, BrandViewModel>().ReverseMap();
        }
    }
}
