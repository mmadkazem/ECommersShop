using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdService : IGetCategoryByIdService
    {
        private readonly DataBaseContext _context;

        public GetCategoryByIdService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetCategoryDetailsDto>> Execute(int id)
        {
            var category = await _context.Categories
                                .Where(c => !c.IsRemoved && c.Id == id)
                                .Select(c => new GetCategoryDetailsDto
                                (
                                    c.Id,
                                    c.Name,
                                    c.InsertTime,
                                    c.UpdateTime
                                ))
                                .FirstOrDefaultAsync();
            if (category is null)
            {
                return new ResultDto<GetCategoryDetailsDto>
                {
                    IsSucssecc = false,
                    Message = "This category dose not exist!!!"
                };
            }

            return new ResultDto<GetCategoryDetailsDto>
            {
                Data = category,
                IsSucssecc = true,
                Message = $"This category by Id: {id}"
            };
        }
    }

}