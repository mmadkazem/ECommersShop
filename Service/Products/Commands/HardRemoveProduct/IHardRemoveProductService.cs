using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Products.Commands.AddNewProduct.HardRemoveProduct
{
    public interface IHardRemoveProductService
    {
        Task<ResultDto> Execute(int id);
    }
}