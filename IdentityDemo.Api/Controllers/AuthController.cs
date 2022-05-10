using IdentityDemo.Api.Interfaces;
using IdentityDemo.Api.Interfaces.Base;
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
        public async Task<IServiceResult> RegisterUser(RegisterViewModel input)
        {
            var result = await _userService.RegisterUser(input);
            return result;
        }
    }
}
