using ECommersShop.Common.Model;
using ECommersShop.Entity.Products;

namespace ECommersShop.Entity.Orders
{
    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        public int PriceProduct { get; set; }
        public int TotalPrice { get; set; }
        public int Count { get; set; }
    }
}