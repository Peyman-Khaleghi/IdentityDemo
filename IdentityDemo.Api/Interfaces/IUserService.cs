using IdentityDemo.Api.Interfaces.Base;
using IdentityDemo.Shared;

namespace IdentityDemo.Api.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResult> RegisterUser(RegisterViewModel input);
    }
}
