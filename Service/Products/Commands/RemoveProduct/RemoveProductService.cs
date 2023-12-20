using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly DataBaseContext _context;

        public RemoveProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var product = await _context.Products
                            .Include(p => p.ProductInCategories)
                            .Where(p => !p.IsRemoved && p.Id == id)
                            .FirstOrDefaultAsync();

            if (product is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This product does not exist!!!"
                };
            }

            product.IsRemoved = true;
            product.RemoveTime = DateTime.Now;
            foreach (var item in product.ProductInCategories)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
            }

            return new ResultDto
            {
                IsSucssecc = true,
                Message  = "This products removed successfully..."
            };
        }
    }
}