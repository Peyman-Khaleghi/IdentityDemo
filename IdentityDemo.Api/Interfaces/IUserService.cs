using IdentityDemo.Api.Interfaces.Base;
using IdentityDemo.Shared;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Api.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResult> RegisterUser(RegisterViewModel input);

        Task<IServiceResult<List<IdentityUser>>> GetAllUser();

        Task<IServiceResult<LoginDto>> LoginUser(LoginViewModel input);
    }
}
