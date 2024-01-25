using System.Data;
using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Orders.Queries.GetOderAll
{
    public interface IGetOrderAllService
    {
        Task<ResultDto<GetOrderDto>> Execute(int userId);
    }

    public class GetOrderAllService : IGetOrderAllService
    {
        private readonly DataBaseContext _context;

        public GetOrderAllService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetOrderDto>> Execute(int userId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(o => o.Product)
                .Include(o => o.User)
                .Where(o => !o.IsRemoved && o.UserId == userId) 
                .FirstOrDefaultAsync();

            if (order is null)
            {
                return new ResultDto<GetOrderDto>
                {
                    IsSucssecc = false,
                    Message = "This order does not exist!!!"
                };
            }
            var orderDto = new GetOrderDto
            {
                Address = order.Address,
                OrderState = order.OrderState,
                UserName = order.User.FullName
            };
            var products = new List<ProductsDto>();
            foreach (var item in order.OrderDetails)
            {
                products.Add(new ProductsDto
                {
                    Count = item.Count,
                    PriceProduct = item.PriceProduct,
                    TotalPrice = item.TotalPrice,
                    ProductId = item.Id,
                    ProductName = item.Product.Name
                });
            }
            orderDto.Products = products;
            return new ResultDto<GetOrderDto>
            {
                Data = orderDto,
                IsSucssecc = true,
                Message = "This Orders"
            };
        }
    }


}