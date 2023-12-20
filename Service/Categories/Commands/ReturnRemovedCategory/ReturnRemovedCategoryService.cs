using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Commands.ReturnRemovedCategory
{
    public class ReturnRemovedCategoryService : IReturnRemovedCategoryService
    {
        private readonly DataBaseContext _context;

        public ReturnRemovedCategoryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var category = await _context.Categories
                            .Include(c => c.ProductInCategories)
                            .Where(c => c.IsRemoved && c.Id == id)
                            .FirstOrDefaultAsync();
            if (category is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This category does not exist!!!"
                };
            }

            category.IsRemoved = false;
            category.RemoveTime = null;
            foreach (var item in category.ProductInCategories)
            {
                item.IsRemoved = false;
                item.RemoveTime = null;
            }
            await _context.SaveChangesAsync();
            
            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This return category removed successfully..."
            };
        }
    }
}