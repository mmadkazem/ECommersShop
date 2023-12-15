using ECommersShop.Entity;
using ECommersShop.FacadPattern.Roles;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Roles
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesSeviceFacad _rolesSevice;

        public RolesController(IRolesSeviceFacad rolesSevice)
        {
            _rolesSevice = rolesSevice;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetRolesByUserId(int usserId)
        {
            var results = await  _rolesSevice
                .GetRolesByUserId.Execute(usserId);
            
            if (!results.IsSucssecc)
            {
                return NotFound(results);
            }

            return Ok(results);
        }
        [HttpPost("{userId}")]
        public async Task<IActionResult> AddNewRoleInUser(int userId, Role role)
        {
            var result = await _rolesSevice
                .AddNewRoleInUser.Execute(userId, role);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateRoleInUser(int userId,
            Role? OldRole, Role? RoleUpdate)
        {
            var result = await _rolesSevice
                .UpdateRoleInUser.Execute(userId, OldRole, RoleUpdate);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        } 
        
        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemovedRolesUser(int userId,
            Role roleRemoved)
        {
            var result = await _rolesSevice
                .RemovedRolesUser.Execute(userId, roleRemoved);
            
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}