using ECommersShop.Common.Dto;
using ECommersShop.Entity;
using ECommersShop.Entity.Cart;
using ECommersShop.Entity.Products;
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
            var cart = new Cart
            {
                User = user,
                UserId = user.Id,
                Finished = false
            };

            var cartItems = new List<CartItem>();
            foreach (var item in model.CartItems)
            {
                var product = await _context.Products
                                .Where(p => !p.IsRemoved && p.Id == item.ProductId)
                                .FirstOrDefaultAsync();
                if (product is null)
                {
                    return new ResultDto
                    {
                        IsSucssecc = false,
                        Message = $"This product {item.ProductId} does not exist!!!"
                    };
                }
                cartItems.Add(new CartItem
                {
                    Cart = cart,
                    CartId = cart.Id,
                    Product = product,
                    ProductId = product.Id,
                    Count = item.Count
                });


            }
            cart.CartItems = cartItems;
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This cart added successfully..."
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