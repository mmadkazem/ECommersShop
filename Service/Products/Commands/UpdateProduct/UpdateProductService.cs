using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Commands.UpdateProduct
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly DataBaseContext _context;

        public UpdateProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id, UpdateProductDto model)
        {
            var product = await _context.Products
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
            product.Name = model.Name;
            product.Brand = model.Brand;
            product.Description = model.Decription;
            product.Inventory = model.Inventory;
            product.Price = model.Price;
            product.Displayed = model.Displayed;
            product.UpdateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This update product successfully..."
            };

        }
    }
}