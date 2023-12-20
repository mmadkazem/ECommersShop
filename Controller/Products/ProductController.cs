using ECommersShop.FacadPattern.Products;
using ECommersShop.Service.Products.Commands.AddNewProduct;
using ECommersShop.Service.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsServiceFacad _productsService;
        public ProductController(IProductsServiceFacad productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var results = await _productsService
                .GetAllProducts.Execute();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> addNewProduc(int id)
        {
            var result = await _productsService
                .GetProductById.Execute(id);
            
            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }
        
            return Ok(result);
        } 

        [HttpPost]
        public async Task<IActionResult> AddNewProduct
        ([FromBody]AddNewProductDto model)
        {
            var result = await _productsService
                .AddNewProduct.Execute(model);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
        
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,
        [FromBody] UpdateProductDto model)
        {
            var result = await _productsService
                .UpdateProduct.Execute(id,model);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
        
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var result = await _productsService
                .RemoveProduct.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
        
            return Ok(result); 
        }
    }
}