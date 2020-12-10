using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Update;
using AspNetCoreHero.Boilerplate.Domain.Entities;
using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Mappings
{
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}
