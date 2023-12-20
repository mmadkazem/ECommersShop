namespace ECommersShop.Service.Products.Commands.AddNewProduct
{
    public class AddNewProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Decription { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
        public List<int> CategoriesId { get; set; }

    }
}