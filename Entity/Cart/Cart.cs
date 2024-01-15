using ECommersShop.Common.Model;
namespace ECommersShop.Entity.Cart
{
    public class Cart : BaseEntity
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public bool Finished { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}