using Microsoft.AspNetCore.Identity;
using Practical_19.Models;

namespace Practical_19.Interface
{
    public interface IAuthentication
    {
        Task<SignInResult> LoginUserAsync(LoginViewModel login);
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel register);
    }
}
