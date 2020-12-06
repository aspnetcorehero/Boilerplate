using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Create;
using AspNetCoreHero.Boilerplate.Domain.Entities;
using AutoMapper;

namespace AspNetCoreHero.Boilerplate.Application.Mappings
{
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}
