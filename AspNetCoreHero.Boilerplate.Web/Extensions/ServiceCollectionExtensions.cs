using AspNetCoreHero.Boilerplate.Web.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreHero.Boilerplate.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMultiLingualSupport(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });
            services.AddRouting(o => o.LowercaseUrls = true);
        }
    }
}
