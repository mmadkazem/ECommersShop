namespace ECommersShop.Service.Roles.Queries.GetRoles
{
    public record GetRolesDto
    (
        string? RoleName,
        DateTime? UpdateTime,
        DateTime? InsertTime
    );
}