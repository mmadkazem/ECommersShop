using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Queries.GetAllRemovedProducts
{
    public class GetAllRemovedProductsService : IGetAllRemovedProductsService
    {
        private readonly DataBaseContext _context;

        public GetAllRemovedProductsService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultsDto<GetAllRemovedProductDto>> Execute()
        {
            var products = await _context.Products
                            .Where(p => !p.IsRemoved)
                            .Select(p => new GetAllRemovedProductDto
                            (
                                p.Id,
                                p.Name,
                                p.Brand,
                                p.Inventory,
                                p.Price,
                                p.Displayed,
                                p.RemoveTime
                            ))
                            .ToListAsync();
            if (products.Count == 0)
            {
                return new ResultsDto<GetAllRemovedProductDto>
                {
                    IsSucssecc = false,
                    Message = "This product does not exist!!!"
                };
            }

            return new ResultsDto<GetAllRemovedProductDto>
            {
                Data = products,
                IsSucssecc = true,
                Message = "This all removed products..."
            };
        }
    }
}