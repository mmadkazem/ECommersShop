using ECommersShop.Common.Dto;
using ECommersShop.Entity;

namespace ECommersShop.Service.Roles.Commands
{
    public interface IAddNewRoleInUserService
    {
        Task<ResultDto> Execute(int userId, Role role);
    }
}