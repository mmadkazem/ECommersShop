using ECommersShop.Common.Model;
using ECommersShop.Entity.Products;

namespace ECommersShop.Entity.Cart
{
    public class CartItem : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        
        public int Count { get; set; }
        public int Price { get; set; }

        public virtual Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}