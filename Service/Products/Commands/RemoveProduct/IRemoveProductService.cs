using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Commands.RemoveProduct
{
    public interface IRemoveProductService
    {
        Task<ResultDto> Execute(int id);
    }
}