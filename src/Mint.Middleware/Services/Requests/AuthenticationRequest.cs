using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Middleware.Extensions;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class AuthenticationRequest : IAuthenticationRequest
{
    public async Task<List<User>> GetUsers()
    {
        var baseRequestService = new RequestService<List<User>>(true);
        return await baseRequestService.GetRequestAsync("api/authentication/getusers");
    }

    public async Task<string> SignIn(UserViewModel user)
    {
        var baseRequestService = new RequestService<string>(false);
        var content = new JsonContent<UserViewModel>().GetContent(user);
        var token = await baseRequestService.PostRequestAsync(content, "api/authentication/signin");
        Params.AccessToken = token; 
        return token;
    }

    public Task SignOut(UserViewModel user)
    {
        throw new NotImplementedException();
    }
}
