using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly DataBaseContext _context;
        public GetAllCategoriesService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultsDto<GetCategoryDto>> Execute()
        {
            var categories = await _context.Categories
                                .Where(c => !c.IsRemoved)
                                .Select(c => new GetCategoryDto(c.Id, c.Name))
                                .ToListAsync();
                                
            return new ResultsDto<GetCategoryDto>
            {
                Data = categories,
                IsSucssecc = false,
                Message = "This all categries..."
            };
        } 
    }
}