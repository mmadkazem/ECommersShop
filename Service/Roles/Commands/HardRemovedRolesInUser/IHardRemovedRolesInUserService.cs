using ECommersShop.Common.Dto;
using ECommersShop.Entity;

namespace ECommersShop.Service.Roles.Commands.HardRemovedRolesInUser
{
    public interface IHardRemovedRolesInUserService
    {
        Task<ResultDto> Execute(int userId, Role roleRemoved);
    }
}