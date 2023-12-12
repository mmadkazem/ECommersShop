using ECommersShop.Common.Model;

namespace ECommersShop.Entity
{
    public class UserInRole : BaseEntity
    {
        public required virtual User User { get; set; }
        public int UserId { get; set; }
        public Role? Role { get; set; }
    }
}