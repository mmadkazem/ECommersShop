using ECommersShop.Common.Model;

namespace ECommersShop.Entity.Products
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<ProductInCategory> ProductInCategories { get; set; }
    }
}