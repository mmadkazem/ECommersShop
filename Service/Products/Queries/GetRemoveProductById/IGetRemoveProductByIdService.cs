using ECommersShop.Common.Dto;
using ECommersShop.Service.Categories.Queries.GetRemovedCategoryById;

namespace ECommersShop.Service.Products.Queries.GetRemoveProductById
{
    public interface IGetRemoveProductByIdService
    {
        Task<ResultDto<GetProductRemovedDetailsDto>> Execute(int id);
    }
}