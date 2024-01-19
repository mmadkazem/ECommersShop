using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Carts.Commands.RemoveCartItem
{
    public interface IRemoveCartItemService
    {
        Task<ResultDto> Execute(int id);
    }
    public class RemoveCartItemService : IRemoveCartItemService
    {
        private readonly DataBaseContext _context;

        public RemoveCartItemService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id)
        {
            var cartItem = await _context.CartItems
                            .Where(c => !c.IsRemoved && c.Id == id)
                            .FirstOrDefaultAsync();
            if (cartItem is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false, 
                    Message = "This cart item does not exist!!!"
                };
            }

            cartItem.IsRemoved = true;
            cartItem.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This cart item removed..."
            };
        }
    }
}