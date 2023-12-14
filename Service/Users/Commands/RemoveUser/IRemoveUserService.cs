using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        Task<ResultDto> Execute(int id);
    }
}