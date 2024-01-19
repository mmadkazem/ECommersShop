using ECommersShop.Common.Dto;
using ECommersShop.Entity.Cart;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Carts.Queries.GetUserCart
{
    public interface IGetUserCartService
    {
        Task<ResultDto<GetUserCartDto>> Execute(int userId);
    }
    public class GetUserCartService : IGetUserCartService
    {
        private readonly DataBaseContext _context;

        public GetUserCartService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<GetUserCartDto>> Execute(int userId)
        {
            var cart = await _context.Carts
                    .Include(c => c.CartItems).ThenInclude(c => c.Product)
                    .Where(c => !c.IsRemoved && c.UserId == userId)
                    .FirstOrDefaultAsync();

            if (cart is null)
            {
                return new ResultDto<GetUserCartDto>
                {
                    IsSucssecc = false,
                    Message = "This User Not Cart"
                };
            }
            var getUserCart = new GetUserCartDto()
            {
                CartId = cart.Id,
            };
            var newProductDeatails = new List<ProductDeatailDto>();
            foreach (var item in cart.CartItems)
            {
                getUserCart.TotalPrice += item.Price * item.Count;
                getUserCart.CountCartItem++;
                newProductDeatails.Add(new ProductDeatailDto
                {
                    CartItemId = item.Id,
                    Name = item.Product.Name,
                    ProductPrice = item.Price,
                    ProductTotalPrice = item.Price * item.Count,
                    Count = item.Count
                });
            }
            getUserCart.ProductDeatails = newProductDeatails;
            return new ResultDto<GetUserCartDto>
            {
                Data = getUserCart,
                IsSucssecc = true,
                Message = "This User Cart"
            };
        }
    }


}