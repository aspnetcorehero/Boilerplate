using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreHero.Boilerplate.Web.Views.Shared.Components.Culture
{
    public class CultureViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
