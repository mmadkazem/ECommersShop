using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Commands.HardRemoveCategory
{
    public interface IHardRemoveCategoryService
    {
        Task<ResultDto> Execute(int id);   
    }
}
