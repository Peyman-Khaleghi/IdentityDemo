using IdentityDemo.Api.Interfaces;
using IdentityDemo.Api.Interfaces.Base;
using IdentityDemo.Api.Services.Base;
using IdentityDemo.Shared;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Api.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManger;

        public UserService(UserManager<IdentityUser> userManger)
        {
            _userManger = userManger;
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
    }
}
