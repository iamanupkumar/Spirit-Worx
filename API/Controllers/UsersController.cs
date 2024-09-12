using Core.Entities;
using Core.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync()
        {
            var data = await _userService.GetAllUserAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetUserByIdAsync")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var data = await _userService.GetUserByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        [Route("RegisterUserAsync")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] Users users)
        {
            var data = await _userService.RegisterUserAsync(users);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateUserAsync")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] Users users)
        {
            var data = await _userService.UpdateUserAsync(users); 
            return Ok(data);
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var data = await _userService.DeleteUserAsync(id);
            return Ok(data);
        }
    }
}
