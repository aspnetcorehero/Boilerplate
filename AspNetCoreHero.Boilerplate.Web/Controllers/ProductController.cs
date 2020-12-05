using AspNetCoreHero.Boilerplate.Application.DTOs.Entities;
using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Infrastructure.DbContexts;
using AspNetCoreHero.Boilerplate.Web.Views.Product.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
                //var categories = await Mediator.Send(new GetAllProductCategoriesQuery());
                var viewModel = new ProductViewModel();
                //var categoriesViewModel = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories.Data);
                //viewModel.ProductCategories = new SelectList(categoriesViewModel, nameof(ProductCategoryViewModel.Id), nameof(ProductCategoryViewModel.Name), null, null);
                var data = new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", viewModel) });
                return data;
            }
            else
            {

                return new JsonResult(new { isValid = true, html = _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", new ProductDto()) });
            }
        }
        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                //Save
                return default;

            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", product);
                return new JsonResult(new { isValid = false, html = html });
            }
                
        }
    }
}
