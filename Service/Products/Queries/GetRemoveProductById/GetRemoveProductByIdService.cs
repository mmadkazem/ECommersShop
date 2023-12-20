using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Queries.GetRemoveProductById
{
    public class GetRemoveProductByIdService : IGetRemoveProductByIdService
    {
        private readonly DataBaseContext _context;

        public GetRemoveProductByIdService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetProductRemovedDetailsDto>> Execute(int id)
        {
            var p = await _context.Products
                            .Where(p => p.IsRemoved && p.Id == id)
                            .Include(p => p.ProductInCategories)
                            .ThenInclude(p => p.Category)
                            .FirstOrDefaultAsync();
            
            var product = new GetProductRemovedDetailsDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Description = p.Description,
                Inventory = p.Inventory,
                Price = p.Price,
                Displayed = p.Displayed,
                RemovedTime = p.RemoveTime,
                UpdateTime = p.UpdateTime,
                InsertTime = p.InsertTime
            };
            var categories = new List<string>();
            foreach (var item in p.ProductInCategories)
            {
                categories.Add(item.Category.Name);
            }
            product.Categories = categories;

            return new ResultDto<GetProductRemovedDetailsDto>
            {
                Data = product,
                IsSucssecc = true,
                Message = "This removed product details..."
            };
        }
    }
}