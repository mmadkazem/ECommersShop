using ECommersShop.Common.Dto;
using ECommersShop.Service.Users.Queries.GetAllUser;

namespace ECommersShop.Service.Users.Queries.GetUserById
{
    public interface IGetUserByIdService
    {
        Task<ResultDto<GetUserDto>> Execute(int id);
    }
}