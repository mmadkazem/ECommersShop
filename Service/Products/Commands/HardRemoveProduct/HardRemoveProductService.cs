using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Commands.AddNewProduct.HardRemoveProduct
{
    public class HardRemoveProductService : IHardRemoveProductService
    {
        private readonly DataBaseContext _context;

        public HardRemoveProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var product = await _context.Products
                            .Where(p => p.IsRemoved && p.Id == id)
                            .FirstOrDefaultAsync();

            if (product is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This product does not exist!!!"
                };
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message  = "This products hard removed successfully..."
            };
        }
    }
}