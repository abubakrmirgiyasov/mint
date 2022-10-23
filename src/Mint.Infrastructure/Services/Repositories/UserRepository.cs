using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.BindingModels;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mint.Infrastructure.Services.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersAync()
    {
        var users = await _context.Users
            .ToListAsync();
        return users;
    }

    public async Task<User> GetUserByIdAync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user ?? throw new ContentNotFoundException("Пользователь не найден");
    }

    public async Task<User> GetUserByEmailAync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user ?? throw new ContentNotFoundException("Пользователь не найден");
    }

    public async Task<User> GetUserByPhoneAync(long phone)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        return user ?? throw new ContentNotFoundException("Пользователь не найден");
    }

    public async Task<User> AddUserAync(UserBindingModel user)
    {
        var similarUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email!);

        if (similarUser != null)
        {
            throw new SimilarUserException("Пользователь с такой почтой существует");
        }

        var newUser = new UserManager().FormingBindingModel(user);

        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
        newUser.RoleId = role!.Id;

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }

    public Task<User> UpdateUserAync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(User id)
    {
        throw new NotImplementedException();
    }

    public async Task<JwtSecurityToken> GetSigninUser(string login, string password)
    {
        var encodedPassword = Encrypt.EncodePassword(password);
        var userWithEmail = await _context.Users
            .Include(x => x.Role)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Email == login && x.Password == encodedPassword);

        if (userWithEmail == null)
        {
            var email = await _context.Users.FirstOrDefaultAsync(x => x.Email == login);

            if (email != null)
            {
                await UpdateNumOfAttempts(email);
            }

            throw new Exception("Неправильный логин/пароль");
        }
        else
        {
            if (userWithEmail!.IsActiveAccount == false)
            {
                throw new UserBlockedException("Ваш аккаунт заблокирован");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userWithEmail.FirstName),
                new Claim(ClaimTypes.Email, userWithEmail.Email),
                new Claim(ClaimTypes.Role, userWithEmail.Role!.Name),
                new Claim(ClaimTypes.NameIdentifier, userWithEmail.Id.ToString()),
                new Claim(ClaimTypes.UserData, "")
            };

            foreach (var item in userWithEmail.Photos!)
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
        // add logic blocking user if count of attempts more then 10 
    }

    private async Task UpdateNumOfAttempts(User user)
    {
        if (user.NumOfAttempts < 10)
        {
            user.NumOfAttempts += 1;
        }
        else
        {
            user.IsActiveAccount = false;
        }

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}
