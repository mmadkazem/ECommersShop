using ECommersShop.Common.Dto;
using ECommersShop.Entity.Cart;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Carts.Commands.AddNewCart
{
    public interface IAddNewCartService
    {
        Task<ResultDto> Execute(AddNewCartDto model);
    }
    public class AddNewCartService : IAddNewCartService
    {
        private readonly DataBaseContext _context;

        public AddNewCartService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddNewCartDto model)
        {
            var user = await _context.Users
                        .Where(u => !u.IsRemoved && u.Id == model.UserId)
                        .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }
            var cart = _context.Carts
            .Where(c => !c.IsRemoved && !c.Finished && c.UserId == model.UserId)
            .FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }


            foreach (var item in model.CartItems)
            {
                var product = await _context.Products
                                .Where(p => !p.IsRemoved && p.Id == item.ProductId)
                                .FirstOrDefaultAsync();
                if (product.Inventory < item.Count)
                {
                    return new ResultDto
                    {
                        IsSucssecc = false,
                        Message = "inventory does not exist!!!"
                    };
                }
                var cartItem = await _context.CartItems
                            .Where(p => p.ProductId == item.ProductId && p.CartId == cart.Id)
                            .FirstOrDefaultAsync();

                if (cartItem is not null)
                {
                    cartItem.Count++;
                    cartItem.TotalPrice = cartItem.PriceProduct * cartItem.PriceProduct;
                }
                else
                {
                    CartItem newCartItem = new CartItem()
                    {
                        Cart = cart,
                        Count = item.Count,
                        TotalPrice = product.Price * item.Count,
                        Product = product,
                    };
                    _context.CartItems.Add(newCartItem);
                    _context.SaveChanges();
                }
            }

            return new ResultDto()
            {
                IsSucssecc = true,
                Message = "This cartItem added successfully..."
            };
        }
    }

    public class AddNewCartDto
    {
        public int UserId { get; set; }

        public List<CartItemDto> CartItems { get; set; }
        public class CartItemDto
        {
            public int ProductId { get; set; }
            public int Count { get; set; }
        }
    }
}