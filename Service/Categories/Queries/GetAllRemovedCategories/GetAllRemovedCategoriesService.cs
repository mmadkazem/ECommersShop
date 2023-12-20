using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Queries.GetAllRemovedCategories
{
    public class GetAllRemovedCategoriesService : IGetAllRemovedCategoriesService
    {
        private readonly DataBaseContext _context;

        public GetAllRemovedCategoriesService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultsDto<GetRemovedCategoriesDto>> Execute()
        {
            var categories = await _context.Categories
                                .Where(c => c.IsRemoved)
                                .Select(c => new GetRemovedCategoriesDto
                                (
                                    c.Id,
                                    c.Name,
                                    c.RemoveTime
                                ))
                                .ToListAsync();
            if (categories.Count == 0)
            {
                return new ResultsDto<GetRemovedCategoriesDto>
                {
                    IsSucssecc = false,
                    Message = "This is categories removed does not exist!!!"
                };
            }
            return new ResultsDto<GetRemovedCategoriesDto>
            {
                Data = categories,
                IsSucssecc = true,
                Message = "This all categries removed..."
            };
        }
    }
}