using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Middleware.Services.Interfaces
{
    public interface IAuthenticationRequest
    {
        Task<string> SignIn(UserBindingModel user);

        Task SignUp(UserBindingModel user);

        Task SignOut(UserBindingModel user);
    }
}
