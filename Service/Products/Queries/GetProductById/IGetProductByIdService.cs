using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Queries.GetProductById
{
    public interface IGetProductByIdService
    {
        Task<ResultDto<GetProductDetailsDto>> Execute(int id);
    }
}