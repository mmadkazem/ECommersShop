using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Commands.ReturnUser
{
    public interface IReturnRemovedUserService
    {
        Task<ResultDto> Execute(int id);
    }
}