using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Queries.GetProductById
{
    public class GetProductByIdService : IGetProductByIdService
    {
        private readonly DataBaseContext _context;

        public GetProductByIdService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetProductDetailsDto>> Execute(int id)
        {
            var p = await _context.Products
                            .Include(p => p.ProductInCategories)
                            .ThenInclude(p => p.Category)
                            .Where(p => !p.IsRemoved && p.Id == id)
                            .FirstOrDefaultAsync();
            if (p is null)
            {
                return new ResultDto<GetProductDetailsDto>
                {
                    IsSucssecc = false,
                    Message = "This product does not exist!!!"
                };
            }
            var product = new GetProductDetailsDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Description = p.Description,
                Inventory = p.Inventory,
                Price = p.Price,
                Displayed = p.Displayed
            };
                
            var categories = new List<string>();
            foreach (var item in p.ProductInCategories)
            {
                categories.Add(item.Category.Name);
            }
            product.Categories = categories;

            return new ResultDto<GetProductDetailsDto>
            {
                Data = product,
                IsSucssecc = true,
                Message = "This product details..."
            };
        }
    }
}