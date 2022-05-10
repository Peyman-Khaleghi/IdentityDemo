using IdentityDemo.Api.Interfaces;
using IdentityDemo.Api.Interfaces.Base;
using IdentityDemo.Api.Services.Base;
using IdentityDemo.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityDemo.Api.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManger;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManger , IConfiguration configuration)
        {
            _userManger = userManger;
            _configuration = configuration;
        }

        public async Task<IServiceResult<List<IdentityUser>>> GetAllUser()
        {
           var result =await _userManger.Users.ToListAsync();

            return ServiceResult<List<IdentityUser>>.Ok(result);
        }

      
        public async Task<IServiceResult> RegisterUser(RegisterViewModel input)
        {
            if (input == null)
            {
                return ServiceResult.BadRequest(ErrorCode.RegisterInputIsNull);
            }

            if (input.Password != input.ConfirmPassword)
            {
                return ServiceResult.BadRequest(ErrorCode.ConfirmPasswordIncorrect);
            }

            var identityUser = new IdentityUser
            {
                Email = input.Email,
                UserName = input.UserName,
                PhoneNumber = input.PhoneNumber,
            };

            var result = await _userManger.CreateAsync(identityUser, input.Password);

            return ServiceResult.Created();
        }

        public async Task<IServiceResult<LoginDto>> LoginUser(LoginViewModel input)
        {
            var user = await _userManger.FindByEmailAsync(input.Email);

            if (user == null)
            {
                return ServiceResult<LoginDto>.BadRequest(ErrorCode.UserNotFoundforEmail);
            }

            var result = await _userManger.CheckPasswordAsync(user, input.Password);

            if (!result)
            {
                return ServiceResult<LoginDto>.BadRequest(ErrorCode.PasswordIsWrong);
            }

            var claims = new[]
            {
                new Claim("Email", input.Email),
                new Claim(ClaimTypes.NameIdentifier , user.Id)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            var loginDto = new LoginDto
            {
                Token = tokenAsString,
                ExpireDate = token.ValidTo,
            };

            return ServiceResult<LoginDto>.Ok(loginDto);
        }
    }
}