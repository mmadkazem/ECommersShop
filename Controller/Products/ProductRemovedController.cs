using ECommersShop.FacadPattern.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductRemovedController : ControllerBase
    {
        private readonly IProductsServiceFacad _productsService;

        public ProductRemovedController(IProductsServiceFacad productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRemovedProducts()
        {
            var result = await _productsService
                .GetAllRemovedProducts.Execute();
            
            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }
        
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRemoveProductById(int id)
        {
            var result = await _productsService
                .GetRemoveProductById.Execute(id);

            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }
        
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnProductRemoved(int id)
        {
            var result = await _productsService
                .ReturnProductRemoved.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
        
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardRemoveProduct(int id)
        {
            var result = await _productsService
                .HardRemoveProduct.Execute(id);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
        
            return Ok(result);
        }
    }
}