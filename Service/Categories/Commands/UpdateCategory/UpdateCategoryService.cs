using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryService : IUpdateCategoryService
    {
        private readonly DataBaseContext _context;

        public UpdateCategoryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id, string nameCategory)
        {
            var category = await _context.Categories
                            .Where(c => !c.IsRemoved && c.Id == id)
                            .FirstOrDefaultAsync();

            if (category is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This category dose not exist!!!"
                };
            }

            category.Name = nameCategory;
            category.UpdateTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This category updated successfully..."
            };
        }
    }
}