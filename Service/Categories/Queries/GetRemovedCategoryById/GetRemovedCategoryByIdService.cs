using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Queries.GetRemovedCategoryById
{
    public class GetRemovedCategoryByIdService : IGetRemovedCategoryByIdService
    {
        private readonly DataBaseContext _context;

        public GetRemovedCategoryByIdService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetRemovedCategoryDetailsDto>> Execute(int id)
        {
            var category = await _context.Categories
                                .Where(c => c.IsRemoved && c.Id == id)
                                .Select(c => new GetRemovedCategoryDetailsDto
                                (
                                    c.Id,
                                    c.Name,
                                    c.InsertTime,
                                    c.RemoveTime,
                                    c.UpdateTime
                                ))
                                .FirstOrDefaultAsync();

            if (category is null)
            {
                return new ResultDto<GetRemovedCategoryDetailsDto>
                {
                    IsSucssecc = false,
                    Message = "This category dose not exist!!!"
                };
            }

            return new ResultDto<GetRemovedCategoryDetailsDto>
            {
                Data = category,
                IsSucssecc = true,
                Message = $"This category by Id: {id}"
            };
        }
    }
}