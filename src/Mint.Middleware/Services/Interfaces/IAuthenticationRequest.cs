using Mint.Domain.BindingModels;

namespace Mint.Middleware.Services.Interfaces
{
    public interface IAuthenticationRequest
    {
        Task<string> SignIn(UserBindingModel user);

        Task SignUp(UserBindingModel user);
    }
}
