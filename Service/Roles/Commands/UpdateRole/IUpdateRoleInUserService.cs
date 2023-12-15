using ECommersShop.Common.Dto;
using ECommersShop.Entity;

namespace ECommersShop.Service.Roles.Commands.UpdateRole
{
    public interface IUpdateRoleInUserService
    {
        Task<ResultDto> Execute(int userId, Role? OldRole, Role? RoleUpdate);
    }

}