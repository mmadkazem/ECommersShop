using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Roles.Queries.GetRoles
{
    public interface IGetRolesByUserIdService
    {
        Task<ResultsDto<GetRolesDto>> Execute(int userId);
    }
}