namespace ECommersShop.Service.Products.Queries.GetRemoveProductById
{
    public record class GetProductRemovedDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public int Price { get; set; }
        public bool Displayed { get; set; }
        public DateTime? RemovedTime { get; set; }
        public DateTime? InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public ICollection<string> Categories { get; set; }
    }
}