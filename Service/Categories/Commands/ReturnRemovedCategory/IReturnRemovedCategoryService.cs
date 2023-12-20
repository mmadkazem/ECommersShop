using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Commands.ReturnRemovedCategory
{
    public interface IReturnRemovedCategoryService
    {
        Task<ResultDto> Execute(int id);
    }
}