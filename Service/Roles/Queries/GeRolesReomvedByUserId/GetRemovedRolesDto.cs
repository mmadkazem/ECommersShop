namespace ECommersShop.Service.Roles.Queries.GeRolesReomvedByUserId
{
    public record GetRemovedRolesDto
    (
        string? RoleName,
        DateTime? RemovedTime,
        DateTime? InsertTime,
        DateTime? UpdateTime
    );
}