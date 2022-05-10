using IdentityDemo.Core.Interfaces.Base;
using IdentityDemo.Shared;

namespace IdentityDemo.Core.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResult> RegisterUser(RegisterViewModel input);
    }
}
