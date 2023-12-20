using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Commands.ReturnProductRemoved
{
    public interface IReturnProductRemovedService
    {
        Task<ResultDto> Execute(int id);
    }
}