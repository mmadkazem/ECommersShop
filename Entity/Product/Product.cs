using ECommersShop.Common.Model;

namespace ECommersShop.Entity.Product
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}