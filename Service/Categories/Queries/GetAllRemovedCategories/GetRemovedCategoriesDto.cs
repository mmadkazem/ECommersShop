namespace ECommersShop.Service.Categories.Queries.GetAllRemovedCategories
{
    public record class GetRemovedCategoriesDto
    (
        int Id, 
        string Name,
        DateTime? RemovedTime
    );
}