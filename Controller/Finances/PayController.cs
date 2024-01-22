using ECommersShop.FacadPattern.Finances;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Finances
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayController : ControllerBase
    {
        private readonly IFinancesServiceFacad _financesService;

        public PayController(IFinancesServiceFacad financesService)
        {
            _financesService = financesService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> ActionResult(int userId)
        {
            var result = await _financesService
                .AddRequestPay.Execute(userId);
            
            if (result is null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}