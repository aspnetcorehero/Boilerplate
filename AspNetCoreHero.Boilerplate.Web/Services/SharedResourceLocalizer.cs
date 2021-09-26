using System;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace AspNetCoreHero.Boilerplate.Web.Services
{
    public class SharedResourceLocalizer
    {
        public readonly IStringLocalizer _localizer;

        public SharedResourceLocalizer(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }

        public LocalizedString GetLocalizedHtmlString(string key, string parameter)
        {
            return _localizer[key, parameter];
        }

    }
}
