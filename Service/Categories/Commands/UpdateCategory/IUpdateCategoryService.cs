using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Commands.UpdateCategory
{
    public interface IUpdateCategoryService
    {
        Task<ResultDto> Execute(int id, string nameCategory);
    }
}