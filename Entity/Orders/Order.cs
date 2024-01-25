using ECommersShop.Common.Model;
using ECommersShop.Entity.Finances;

namespace ECommersShop.Entity.Orders
{
    public class Order : BaseEntity
    {

        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual RequestPay RequestPay { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public OrderState OrderState { get; set; }
        public string Address { get; set; }
    }
}