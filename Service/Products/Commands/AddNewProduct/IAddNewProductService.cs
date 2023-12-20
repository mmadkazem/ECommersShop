using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        Task<ResultDto> Execute(AddNewProductDto model);
    }
}