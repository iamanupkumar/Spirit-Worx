using Core.Entities;
using Core.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly UserService _userService;

        public AccessController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("LoginAsync")]
        public async Task<ActionResult> LoginAsync([FromQuery] string emailId, string password) 
        {
            var isLogin =  await _userService.LoginAsync(emailId, password);
            return Ok(isLogin);
        }
    }
}
