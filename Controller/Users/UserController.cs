using ECommersShop.FacadPattern;
using ECommersShop.Service.Users.Commands.RegisterUser;
using ECommersShop.Service.Users.Commands.UpdateUser;
using Microsoft.AspNetCore.Mvc;

namespace ECommersShop.Controller.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsersServicesFacad _usersServicesFacad;

        public UserController(IUsersServicesFacad usersServicesFacad)
        {
            _usersServicesFacad = usersServicesFacad;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var results = await _usersServicesFacad
                .GetAllUsers.Execute();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _usersServicesFacad
                .GetUserById.Execute(id);

            if (!result.IsSucssecc)
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto model)
        {
            var result = await _usersServicesFacad
                .RegisterUser.Execute(model);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, 
                                        [FromBody] UpdateUserDto model)
        {
            var result = await _usersServicesFacad
                .UpdateUser.Execute(id, model);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var result = await _usersServicesFacad.RemoveUser.Execute(id);

            if (!result.IsSucssecc)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}