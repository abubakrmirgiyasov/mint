using Mint.Domain.Models;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class UserRequest : IUserRequest
{
    public async Task<List<User>> GetUsers()
    {
        var baseRequestService = new RequestService<List<User>>(true);
        return await baseRequestService.GetRequestAsync("api/authentication/getusers");
    }

    public async Task<User> GetUserById(Guid id)
    {
        var baseRequestService = new RequestService<User>(true);
        return await baseRequestService.GetRequestAsync($"api/Authentication/GetUserById/{id}");
    }
}
