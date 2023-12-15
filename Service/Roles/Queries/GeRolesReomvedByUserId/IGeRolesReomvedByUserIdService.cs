using ECommersShop.Common.Dto;
using ECommersShop.Service.Roles.Queries.GetRoles;

namespace ECommersShop.Service.Roles.Queries.GeRolesReomvedByUserId
{
    public interface IGetRolesReomvedByUserIdService
    {
        Task<ResultsDto<GetRemovedRolesDto>> Execute(int userId);
    }
}