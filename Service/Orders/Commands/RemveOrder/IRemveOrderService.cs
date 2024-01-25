using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Orders.Commands.RemveOrder
{
    public interface IRemveOrderService
    {
        Task<ResultDto> Execute(int id);
    }
    public class RemveOrderService : IRemveOrderService
    {
        private readonly DataBaseContext _context;

        public RemveOrderService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => !o.IsRemoved && o.Id == id)
                .FirstOrDefaultAsync();

            if (order is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This order does not exist!!!"
                };
            }
            order.IsRemoved = true;
            order.RemoveTime = DateTime.Now;

            foreach (var item in order.OrderDetails)
            {
                item.IsRemoved = true;
                item.RemoveTime = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This order item removed..."
            };
        }
    }
}