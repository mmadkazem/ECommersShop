using ECommersShop.FacadPattern;
using ECommersShop.Service.Users.Commands.HardRemoveUser;
using ECommersShop.Service.Users.Commands.ReturnUser;
using ECommersShop.Service.Users.Queries.GetAllUserRemoved;
using ECommersShop.Service.Users.Queries.GetUserReomvedById;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRemovedController : ControllerBase
    {
        private readonly IUsersServicesFacad _userServiceFacad;

        public UserRemovedController(IUsersServicesFacad userServiceFacad)
        {
            _userServiceFacad = userServiceFacad;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRemoved()
        {
            var results = await _userServiceFacad
                .GetAllUserRemoved.Execute();

            if (!results.IsSucssecc)
            {
                return NotFound(results);
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserRemovedById(int id)
        {
            var result = await _userServiceFacad
                .GetUserRemovedById.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ReturnRemovedUser(int id)
        {
            var result = await _userServiceFacad
                .ReturnRemovedUser.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardRemoveUser(int id)
        {
            var result = await _userServiceFacad
                .HardRemovedUser.Execute(id);
                
            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}