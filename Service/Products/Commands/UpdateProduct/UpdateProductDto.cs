namespace ECommersShop.Service.Products.Commands.UpdateProduct
{
    public record class UpdateProductDto
    (
        string Name,
        string Brand,
        string Decription,
        int Price,
        int Inventory,
        bool Displayed
    );
}