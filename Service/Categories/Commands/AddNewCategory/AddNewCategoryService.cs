using ECommersShop.Common.Dto;
using ECommersShop.Entity.Products;
using ECommersShop.Persistance;

namespace ECommersShop.Service.Categories.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly DataBaseContext _context;

        public AddNewCategoryService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(string NameCategory)
        {
            if (string.IsNullOrWhiteSpace(NameCategory))
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This name category empty!!!"
                };
            }
            var category = new Category
            {
                Name = NameCategory
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This is added category successfully..."
            };
        }
    }
}