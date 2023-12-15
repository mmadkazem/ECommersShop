using ECommersShop.Common.Model;

namespace ECommersShop.Entity
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}