namespace ECommersShop.Service.Users.Queries.GetAllUserRemoved
{
    public record GetRemovedUserDto(
        int Id,
        string? FullName,
        string? Email,
        DateTime? RemovedTime,
        DateTime InSertTime);
}