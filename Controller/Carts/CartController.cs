using ECommersShop.FacadPattern.Carts;
using ECommersShop.Service.Carts.Commands.AddNewCart;
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
        public async Task<IActionResult> ActionResult(
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
    }
}