using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Queries.GetAllRemovedCategories
{
    public interface IGetAllRemovedCategoriesService
    {
        Task<ResultsDto<GetRemovedCategoriesDto>> Execute();
    }
}