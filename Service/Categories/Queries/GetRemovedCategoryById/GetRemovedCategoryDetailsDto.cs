namespace ECommersShop.Service.Categories.Queries.GetRemovedCategoryById
{
    public record class GetRemovedCategoryDetailsDto
    (
        int Id,
        string Name,
        DateTime? InsertTime,
        DateTime? RemovedTime,
        DateTime? UpdatedTime
    );
}