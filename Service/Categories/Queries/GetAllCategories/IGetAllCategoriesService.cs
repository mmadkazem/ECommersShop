using System.Security.Authentication;
using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        Task<ResultsDto<GetCategoryDto>> Execute();
    }
}