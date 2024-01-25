using ECommersShop.Common.Model;
using ECommersShop.Entity.Orders;

namespace ECommersShop.Entity.Finances
{
    public class RequestPay: BaseEntity<Guid>
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public int RefId { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }

}