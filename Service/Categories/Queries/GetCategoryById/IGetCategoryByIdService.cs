using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Queries.GetCategoryById
{
    public interface IGetCategoryByIdService
    {
        Task<ResultDto<GetCategoryDetailsDto>> Execute(int id);
    }

}