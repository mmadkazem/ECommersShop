using ECommersShop.Common.Model;

namespace ECommersShop.Entity.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }

        public virtual ICollection<ProductInCategory> ProductInCategories { get; set; }
    }
}