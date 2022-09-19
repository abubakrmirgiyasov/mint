using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAync();

    Task<User> GetUserByIdAync(Guid id);

    Task<User> GetUserByEmailAync(string email);

    Task<User> GetUserByPhoneAync(long phone);

    Task<User> AddUserAync(User user);

    Task<User> UpdateUserAync(User user);

    Task<User> DeleteUserAsync(User id);
}
