using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreHero.Boilerplate.Web.Views.Shared.Components.Logout
{
    public class LogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
