using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Commands.ReturnProductRemoved
{
    public class ReturnProductRemovedService : IReturnProductRemovedService
    {
        private readonly DataBaseContext _context;

        public ReturnProductRemovedService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var product = await _context.Products
                            .Include(p => p.ProductInCategories)
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

            product.IsRemoved = false;
            product.RemoveTime = null;
            foreach (var item in product.ProductInCategories)
            {
                item.IsRemoved = false;
                item.RemoveTime = null;
            }
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message  = "This return products removed successfully..."
            };
        }
    }
}