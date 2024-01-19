using ECommersShop.FacadPattern.Carts;
using ECommersShop.Service.Carts.Commands.AddNewCart;
using ECommersShop.Service.Carts.Commands.UpdateCountCartItem;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Carts
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartServiceFacad _cartService;

        public CartController(ICartServiceFacad cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewCart(
            [FromBody] AddNewCartDto model)
        {
            var result = await _cartService
                .AddNewCart.Execute(model);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            var result = await _cartService
                .GetUserCart.Execute(userId);

            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }

            return Ok(result.Data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountCartItem(int id, CountType countType)
        {
            var result = await _cartService
                .UpdateCountCartItem.Execute(id, countType);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            var result = await _cartService
                .RemoveCartItem.Execute(id);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}