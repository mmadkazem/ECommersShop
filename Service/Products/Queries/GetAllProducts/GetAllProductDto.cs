namespace ECommersShop.Service.Products.Queries
{
    public record class GetAllProductDto 
    (
        int Id,
        string Name,
        string Brand,
        int Inventory,
        int Price,
        bool Displayed
    );
}