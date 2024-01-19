namespace ECommersShop.Service.Carts.Queries.GetUserCart
{
    public class GetUserCartDto
    {
        public int CartId { get; set; }
        public int TotalPrice { get; set; }
        public int CountCartItem { get; set; }
        public List<ProductDeatailDto> ProductDeatails { get; set; }
    }
    public class ProductDeatailDto
    {
        public int CartItemId { get; set; }
        public string Name { get; set; }
        public int ProductPrice { get; set; }
        public int ProductTotalPrice { get; set; }
        public int Count { get; set; }
    }

}