using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Commands.HardRemoveUser
{
    public interface IHardRemovedUserService
    {
        Task<ResultDto> Execute(int id);
    }
}