using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Queries.GetAllRemovedProducts
{
    public interface IGetAllRemovedProductsService
    {
        Task<ResultsDto<GetAllRemovedProductDto>> Execute();
    }
}