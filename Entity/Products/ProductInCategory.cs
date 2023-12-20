using ECommersShop.Common.Model;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ECommersShop.Entity.Products
{
    public class ProductInCategory : BaseEntity
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        public virtual Category Category { get; set; }
        public int CategryId { get; set; }
    }
}