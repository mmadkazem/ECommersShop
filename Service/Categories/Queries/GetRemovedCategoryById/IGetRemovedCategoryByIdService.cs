using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Queries.GetRemovedCategoryById
{
    public interface IGetRemovedCategoryByIdService
    {
        Task<ResultDto<GetRemovedCategoryDetailsDto>> Execute(int id);
    }
}