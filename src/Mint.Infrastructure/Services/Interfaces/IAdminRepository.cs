using Mint.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Mint.Infrastructure.Services.Interfaces;

public interface IAdminRepository
{
    Task<Admin> GetAdminsAsync();

    Task<Admin> GetAdminByIdAsync(Guid id);

    Task<Admin> GetAdminByEmail(string email);

    Task<JwtSecurityToken> Login(string username, string password);

    Task UpdateNumOfAttempts(Admin admin);
}
