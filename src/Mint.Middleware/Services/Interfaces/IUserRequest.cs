using Mint.Domain.Models;

namespace Mint.Middleware.Services.Interfaces;

public interface IUserRequest
{
    Task<List<User>> GetUsers();

    Task<User> GetUserById(Guid id);
}

