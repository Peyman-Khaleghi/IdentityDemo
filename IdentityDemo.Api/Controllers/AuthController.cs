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
        private readonly IMailService _mailService;

        public AuthController(IUserService userService , IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
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
            await _mailService.SendEmailAsync(input.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " + DateTime.Now + "</p>");
            return result;
        }
    }
}
