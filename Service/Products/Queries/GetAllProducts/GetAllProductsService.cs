using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Queries
{
    public class GetAllProductsService : IGetAllProductsService
    {
        private readonly DataBaseContext _context;
        public GetAllProductsService(DataBaseContext context) => _context = context;

        public async Task<ResultsDto<GetAllProductDto>> Execute()
        {
            var products = await _context.Products
                            .Include(p => p.ProductInCategories)
                            .Where(u => !u.IsRemoved)
                            .Select(p => new GetAllProductDto
                            (
                                p.Id,
                                p.Name,
                                p.Brand,
                                p.Inventory,
                                p.Price,
                                p.Displayed
                            ))
                            .ToListAsync();
            
            return new ResultsDto<GetAllProductDto>
            {
                Data = products,
                IsSucssecc = true,
                Message = "This all products..."
            };
        }
    }
}