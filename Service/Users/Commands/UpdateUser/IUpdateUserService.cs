using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Commands.UpdateUser
{
    public interface IUpdateUserService
    {
        Task<ResultDto> Execute(int id, UpdateUserDto model);
    }
}