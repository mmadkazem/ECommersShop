using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Queries
{
    public interface IGetAllProductsService
    {
        Task<ResultsDto<GetAllProductDto>> Execute();
        
    }
}