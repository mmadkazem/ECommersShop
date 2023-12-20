using ECommersShop.FacadPattern.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Categories
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryRemovedController : ControllerBase
    {
        private readonly ICategoriesServiceFacad _categoriesService;

        public CategoryRemovedController(ICategoriesServiceFacad categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRemovedCategories()
        {
            var results = await _categoriesService
                .GetAllRemovedCategories.Execute();

            if (!results.IsSucssecc)
            {
                return NotFound(results);
            }

            return Ok(results);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRemovedCategoryById(int id)
        {
            var result = await _categoriesService
                .GetRemovedCategoryById.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> addNewCateg(int id)
        {
            var result = await _categoriesService
                .ReturnRemovedCategory.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardRemoveCategory(int id)
        {
            var result = await _categoriesService
                .HardRemoveCategory.Execute(id);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}