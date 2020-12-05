using AspNetCoreHero.Abstractions.Domain;

namespace AspNetCoreHero.Boilerplate.Domain.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Tax { get; set; }
    }
}
