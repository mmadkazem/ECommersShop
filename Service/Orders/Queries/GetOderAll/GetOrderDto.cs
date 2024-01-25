using ECommersShop.Entity.Orders;

namespace ECommersShop.Service.Orders.Queries.GetOderAll
{
    public class GetOrderDto
    {
        public string UserName { get; set; }
        public OrderState OrderState { get; set; }
        public string Address { get; set; }
        public List<ProductsDto> Products { get; set; }
    }
    public class ProductsDto
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int PriceProduct { get; set; }
        public int TotalPrice { get; set; }
    }

}