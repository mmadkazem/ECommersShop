using ECommersShop.Common.Model;
using ECommersShop.Entity.Orders;

namespace ECommersShop.Entity
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}