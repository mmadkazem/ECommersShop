using ECommersShop.FacadPattern.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesServiceFacad _categoriesService;

        public CategoryController(ICategoriesServiceFacad categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var results = await _categoriesService
                .GetAllCategories.Execute();
            
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> addNewCategor(int id)
        {
            var result = await _categoriesService
                .GetCategoryById.Execute(id);
            
            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(string nameCategory)
        {
            var result = await _categoriesService
                .AddNewCategory.Execute(nameCategory);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, string nameCategory)
        {
            var result = await _categoriesService
                .UpdateCategory.Execute(id, nameCategory);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategry(int id)
        {
            var result = await _categoriesService
                .RemoveCategry.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}