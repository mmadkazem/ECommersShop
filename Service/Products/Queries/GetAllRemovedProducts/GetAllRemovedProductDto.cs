namespace ECommersShop.Service.Products.Queries.GetAllRemovedProducts
{
    public record class GetAllRemovedProductDto
    (
        int Id,
        string Name,
        string Brand,
        int Inventory,
        int Price,
        bool Displayed,
        DateTime? RemovedTime
    );
}