namespace ECommersShop.Service.Products.Queries.GetProductById
{
    public class GetProductDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
        public ICollection<string> Categories { get; set; }
    }
}