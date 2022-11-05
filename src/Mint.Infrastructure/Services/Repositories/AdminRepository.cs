using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.BindingModels;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mint.Infrastructure.Services.Repositories;

public class AdminRepository : IAdminRepository
{
	private readonly ApplicationDbContext _context;

	public AdminRepository(ApplicationDbContext context)
	{
		_context = context;
	}

    public Task<Admin> GetAdminsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Admin> GetAdminByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Admin> GetAdminByEmail(string email)
	{
		try
		{
			var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == email);
			return admin!;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

    public async Task<JwtSecurityToken> Login(string login, string password)
    {
        var encodedPassword = Encrypt.EncodePassword(password);
        var admin = await _context.Admins
            .Include(x => x.Role)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Email == login && x.Password == encodedPassword);

        if (admin == null)
        {
            var email = await _context.Admins.FirstOrDefaultAsync(x => x.Email == login);

            if (email != null)
            {
                await UpdateNumOfAttempts(email);
            }

            throw new Exception("Неправильный логин/пароль");
        }
        else
        {
            if (admin!.IsActive == false)
            {
                throw new UserBlockedException("Ваш аккаунт заблокирован");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.FirstName),
                new Claim(ClaimTypes.GivenName, admin.SecondName),
                new Claim(ClaimTypes.Email, admin.Email),
                new Claim(ClaimTypes.Role, admin.Role!.Name),
            };

            foreach (var item in admin.Photos!)
            {
                claims.Add(new Claim(ClaimTypes.UserData, item.FileBytes.ToString()!));
            }

            var token = new JwtSecurityToken(
                issuer: Constants.ISSUER,
                audience: Constants.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10), // test
                signingCredentials: new SigningCredentials(
                    Constants.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return token;
        }
    }

    public Task UpdateNumOfAttempts(Admin admin)
    {
        throw new NotImplementedException();
    }
}
