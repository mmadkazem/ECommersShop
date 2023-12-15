using ECommersShop.Common.Dto;
using ECommersShop.Entity;

namespace ECommersShop.Service.Roles.Commands.RemovedRolesUser
{
    public interface IRemovedRolesUserService
    {
        Task<ResultDto> Execute(int userId, Role role);
    }
}