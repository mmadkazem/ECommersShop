using ECommersShop.Common.Dto;
using ECommersShop.Entity.Orders;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Orders.Commands
{
    public interface IAddNewOrderServise
    {
        Task<ResultDto> Execute(AddNewOrderDto addNewOrder);
    }

    public class AddNewOrderServise : IAddNewOrderServise
    {
        private readonly DataBaseContext _context;

        public AddNewOrderServise(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddNewOrderDto model)
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
            var requestPay = await _context.RequestPays
                .Where(r => !r.IsRemoved && r.UserId == model.UserId)
                .FirstOrDefaultAsync();

            if (requestPay is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This requestPay does not exist!!!"
                };
            }

            var cart = _context.Carts
                .Include(p => p.CartItems).ThenInclude(p=> p.Product)
                .Where(p => p.UserId == model.UserId)
                .FirstOrDefault();
            
            if (cart is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This cart does not exist!!!"
                };
            }

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;

            cart.Finished = true;

            var order = new Order()
            {
                Address = model.Address,
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,
            };

            await _context.Orders.AddAsync(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {

                orderDetails.Add(new OrderDetail
                {
                    Count = item.Count,
                    Order = order,
                    PriceProduct = item.PriceProduct,
                    TotalPrice = item.TotalPrice,
                    Product = item.Product,
                });
            }


            await _context.OrderDetails.AddRangeAsync(orderDetails);

            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSucssecc = true,
                Message = "This cartItem added successfully..."
            };
        }
    }

    public class AddNewOrderDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
    }
}