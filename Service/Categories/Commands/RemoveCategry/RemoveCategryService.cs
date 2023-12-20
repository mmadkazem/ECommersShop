using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Commands.RemoveCategry
{
    public class RemoveCategryService : IRemoveCategryService
    {
        private readonly DataBaseContext _context;

        public RemoveCategryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var category = await _context.Categories
                            .Include(c => c.ProductInCategories)
                            .Where(c => !c.IsRemoved && c.Id == id)
                            .FirstOrDefaultAsync();
            if (category is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This category does not exist!!!"
                };
            }

            category.IsRemoved = true;
            category.RemoveTime = DateTime.Now;

            foreach (var item in category.ProductInCategories)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
            }
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This category removed successfully..."
            };
        }
    }
}