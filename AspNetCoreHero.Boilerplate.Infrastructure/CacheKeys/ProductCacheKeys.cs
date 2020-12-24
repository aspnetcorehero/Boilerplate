namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys
{
    public static class ProductCacheKeys
    {
        public static string ListKey => "ProductList";

        public static string SelectListKey => "ProductSelectList";

        public static string GetKey(int productId) => $"Product-{productId}";

        public static string GetDetailsKey(int productId) => $"ProductDetails-{productId}";
    }
}