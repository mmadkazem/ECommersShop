using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Carts.Commands.UpdateCountCartItem
{
    public interface IUpdateCountCartItemService
    {
        Task<ResultDto> Execute(int id, CountType countType);
    }
    public enum CountType
    {
        Add = 1,
        Low = 2,
    }
    public class UpdateCountCartItemService : IUpdateCountCartItemService
    {
        private readonly DataBaseContext _context;

        public UpdateCountCartItemService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int id, CountType countType)
        {
            var cartItem = await _context.CartItems
                            .Where(c => !c.IsRemoved && c.Id == id)
                            .Include(c => c.Product)
                            .FirstOrDefaultAsync();
            if (cartItem is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This cart item does not exist!!!"
                };
            }

            
            if (countType == CountType.Add)
            {
                var productInventory = cartItem.Product.Inventory;
                if (cartItem.Count + 1 > productInventory)
                {
                    return new ResultDto
                    {
                        IsSucssecc = false,
                        Message = "inventory does not exist!!!"
                    };
                }
                cartItem.Count++;
                await _context.SaveChangesAsync();
                return new ResultDto
                {
                    IsSucssecc = true,
                    Message = "This added count cart item successfully..."
                };
            }
            if (cartItem.Count == 1)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "The count is one and cannot be subtracted from it!!!"
                };
            }
            cartItem.Count--;
            await _context.SaveChangesAsync();
            return new ResultDto
                {
                    IsSucssecc = true,
                    Message = "This subtracted count cart item successfully..."
                };
        }
    }
}