using ECommersShop.FacadPattern.Orders;
using ECommersShop.Service.Orders.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrserFacadService _ordersService;

        public OrdersController(IOrserFacadService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] AddNewOrderDto model)
        {
            var result = await _ordersService
                .AddNewOrder.Execute(model);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOrderAll(int userId)
        {
            var result = await _ordersService
                .GetOrderAll.Execute(userId);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemveOrder(int userId)
        {
            var result = await _ordersService
                .RemveOrder.Execute(userId);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            
            return Ok(result);
        }
    }
}