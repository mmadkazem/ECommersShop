using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        Task<ResultDto> Execute(string NameCategory);
    }
}