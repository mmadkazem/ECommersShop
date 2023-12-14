using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Queries.GetAllUser
{
    public interface IGetAllUsersService
    {
        Task<ResultsDto<GetUserDto>> Execute();
    }
}