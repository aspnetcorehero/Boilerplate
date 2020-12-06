using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Update;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById;
using AspNetCoreHero.Boilerplate.Infrastructure.DbContexts;
using AspNetCoreHero.Boilerplate.Web.Extensions;
using AspNetCoreHero.Boilerplate.Web.Views.Product.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        public readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ProductViewModel();
            //model.Products = await _mediator.Send(new GetAllProductsCachedQuery());
            return View(model);
        }
        public async Task<IActionResult> LoadAll()
        {
            var products = await _mediator.Send(new GetAllProductsCachedQuery());
            return PartialView("_ViewAll", products);
        }
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                var product = new ProductViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", product) });
            }
            else
            {
                var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
                if (product.Succeeded)
                {
                    var productViewModel = _mapper.Map<ProductViewModel>(product.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", productViewModel) });
                }
                return null;
            }
        }
        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    product.Image = file.OptimizeImageSize(700, 700);
                }

                if (id == 0)
                {
                    var createProductCommand = _mapper.Map<CreateProductCommand>(product);
                    var result = await _mediator.Send(createProductCommand);
                    if (result.Succeeded) _notify.Success($"Product Created.");
                }
                else
                {
                    //if (product.Image == null)
                    //{
                    //    var oldProduct = await _mediator.Send(new GetProductByIdQuery { Id = id });
                    //    product.Image = oldProduct.Data.Image;
                    //}
                    var updateProductCommand = _mapper.Map<UpdateProductCommand>(product);
                    var result = await _mediator.Send(updateProductCommand);
                    //try
                    //{
                    //    var result = await Mediator.Send(updateProductCommand);
                    //    if (result.Succeeded) Notify.AddSuccessToastMessage($"Product Updated.");
                    //}
                    //catch (Exception ex)
                    //{
                    //    //Logger.LogInformation(ex.Message);
                    //    throw;
                    //}

                }
                var products = await _mediator.Send(new GetAllProductsCachedQuery());
                var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", products);
                return new JsonResult(new { isValid = true, html = html });

            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", product);
                return new JsonResult(new { isValid = false, html = html });
            }
                
        }
    }
}
