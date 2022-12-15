using Mint.Domain.BindingModels;
using Mint.Middleware.Extensions;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class AuthenticationRequest : IAuthenticationRequest
{
    public async Task<string> SignIn(UserBindingModel user)
    {
        var baseRequestService = new RequestService<string>(false);
        var content = new JsonContent<UserBindingModel>().GetContent(user);
        var token = await baseRequestService.PostRequestAsync(content, Url.SIGN_IN);

        ////
        Params.AccessToken = token;
        ////

        return token;
    }

    public async Task SignUp(UserBindingModel user)
    {
        var baseRequestService = new RequestService<UserBindingModel>(false);
        var content = new JsonContent<UserBindingModel>().GetContent(user);
        await baseRequestService.PostRequestAsync(content, Url.SIGN_UP);
    }
}
