using ECommersShop.Entity;
using ECommersShop.FacadPattern.Roles;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Roles
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesRemovedController : ControllerBase
    {
        private readonly IRolesSeviceFacad _rolesSevice;

        public RolesRemovedController(IRolesSeviceFacad rolesSevice)
        {
            _rolesSevice = rolesSevice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolesReomvedByUserId(int id)
        {
            var results = await _rolesSevice
                .GetRolesReomvedByUserId.Execute(id);

            if (!results.IsSucssecc)
            {
                return NotFound(results);
            }

            return Ok(results);
        }
        
        [HttpDelete("{userId}")]
        public async Task<IActionResult> HardRemovedRolesInUser(int userId, Role roleRemove)
        {
            var result = await _rolesSevice
                .HardRemovedRolesInUser.Execute(userId, roleRemove);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}