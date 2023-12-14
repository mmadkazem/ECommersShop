using ECommersShop.Common.Dto;
using ECommersShop.Service.Users.Queries.GetAllUserRemoved;

namespace ECommersShop.Service.Users.Queries.GetUserReomvedById
{
    public interface IGetUserRemovedByIdService
    {
        Task<ResultDto<GetRemovedUserDto>> Execute(int id);
    }

}