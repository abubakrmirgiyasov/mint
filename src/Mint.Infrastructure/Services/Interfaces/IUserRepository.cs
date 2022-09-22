using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAync();

    Task<User> GetUserByIdAync(Guid id);

    Task<User> GetUserByEmailAync(string email);

    Task<User> GetUserByPhoneAync(long phone);

    Task<User> AddUserWithPhoneAync(User user);

    Task<User> AddUserWithEmailAync(User user);

    Task<User> UpdateUserAync(User user);

    Task<User> DeleteUserAsync(User id);

    Task<User> GetSigninUser(string login, string password);

    Task<User> SigninAsync(User user);
}
