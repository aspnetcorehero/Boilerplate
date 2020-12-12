namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys
{
    public static class BrandCacheKeys
    {
        public static string ListKey => "BrandList";

        public static string SelectListKey => "BrandSelectList";

        public static string GetKey(int brandId) => $"Brand-{brandId}";

        public static string GetDetailsKey(int brandId) => $"BrandDetails-{brandId}";
    }
}
