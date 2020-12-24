using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Web.Abstractions
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}