using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        Task<ResultDto> Execute(RegisterUserDto model);
    }
}