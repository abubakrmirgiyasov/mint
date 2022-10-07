using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

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

    Task<JwtSecurityToken> GetSigninUser(string login, string password);
}
