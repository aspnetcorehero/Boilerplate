using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public int BrandId { get; set; }
        public SelectList Brands { get; set; }
    }
}