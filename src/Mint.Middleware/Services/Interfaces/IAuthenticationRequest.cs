using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Middleware.Services.Interfaces
{
    public interface IAuthenticationRequest
    {
        Task<string> SignIn(UserViewModel user);

        Task SignOut(UserViewModel user);
    }
}
