using Mint.Domain.BindingModels;
using Mint.Middleware.Extensions;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class AdminRequestService : IAdminRequestService
{
    public async Task<string> Login(AdminBindingModel admin)
    {
        var baseRequestService = new RequestService<string>(false);
        var content = new JsonContent<AdminBindingModel>().GetContent(admin);
        var token = await baseRequestService.PostRequestAsync(content, "api/admin/login");
        Params.AccessToken = token;
        return token;
    }
}
