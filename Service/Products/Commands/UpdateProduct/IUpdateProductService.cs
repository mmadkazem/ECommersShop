using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Commands.UpdateProduct
{
    public interface IUpdateProductService
    {
        Task<ResultDto> Execute(int id, UpdateProductDto model);
    }
}