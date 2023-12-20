namespace ECommersShop.Service.Categories.Queries.GetCategoryById
{
    public record class GetCategoryDetailsDto
    (
        int Id,
        string Name,
        DateTime? InsertTime,
        DateTime? UpdateTime
    );

}