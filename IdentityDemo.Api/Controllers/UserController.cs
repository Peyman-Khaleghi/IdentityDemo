using IdentityDemo.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Users")]
        // /api/user/users
        public async Task<object> GetUsers()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            return await _userService.GetAllUser();
        }
    }
}
