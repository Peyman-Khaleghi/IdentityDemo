using IdentityDemo.Api.Interfaces;
using IdentityDemo.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        // /api/auth/register
        public async Task<object> RegisterUser(RegisterViewModel input)
        {
            var result = await _userService.RegisterUser(input);
            return result;
        }

        [HttpPost("Login")]
        // /api/auth/Login
        public async Task<object> LoginUser(LoginViewModel input)
        {
            var result = await _userService.LoginUser(input);
            return result;
        }
    }
}
