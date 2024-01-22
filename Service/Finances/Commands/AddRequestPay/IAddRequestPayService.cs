using ECommersShop.Common.Dto;
using ECommersShop.Entity.Finances;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Finances.Commands
{
    public interface IAddRequestPayService
    {
        Task<ResultDto<Guid>> Execute(int userId); 
    }
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly DataBaseContext _context;

        public AddRequestPayService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<Guid>> Execute(int userId)
        {
            var user = await _context.Users
                .Where(r => !r.IsRemoved && r.Id == userId)
                .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto<Guid>
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }
            var cart = await _context.Carts
                .Where(c => !c.IsRemoved && c.UserId == userId)
                .Include(c => c.CartItems).ThenInclude(c => c.Product)
                .FirstOrDefaultAsync();
            var requestPay = new RequestPay
            {
                Id = Guid.NewGuid(),
                IsPay = false,
                User = user,
                Amount = cart.CartItems.Sum(c => c.TotalPrice)
            };
            _context.RequestPays.Add(requestPay);
            await _context.SaveChangesAsync();
            return new ResultDto<Guid>
            {
                Data = requestPay.Id,
                IsSucssecc = true,
                Message = "This added RequestPay successfully..."
            };
        }
    }
}