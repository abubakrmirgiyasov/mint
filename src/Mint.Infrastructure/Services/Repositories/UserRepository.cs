using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
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

    public async Task<User> AddUserWithPhoneAync(User user)
    {
        _ = await GetUserByPhoneAync(user.Phone) ?? throw new Exception("Пользователь с таким телефоном существует");

        user.Password = Encrypt.EncodePassword(user.Password);
        user.ConfirmedPassword = Encrypt.EncodePassword(user.ConfirmedPassword);

        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
        user.RoleId = role!.Id;

        var photos = await _context.AddPhotoAsync(user.Files!);
        //user.Photos = photos;

        if (user.Password == user.ConfirmedPassword)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        return null!;
    }

    public async Task<User> AddUserWithEmailAync(User user)
    {
        _ = await GetUserByEmailAync(user.Email) ?? throw new Exception("Пользователь с такой почтой существует");

        user.Password = Encrypt.EncodePassword(user.Password);
        user.ConfirmedPassword = Encrypt.EncodePassword(user.ConfirmedPassword);

        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
        user.RoleId = role!.Id;

        var photos = await _context.AddPhotoAsync(user.Files!);
        //user.Photos = photos;

        if (user.Password == user.ConfirmedPassword)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
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
            //.Include(x => x.Photos)
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
                new Claim(ClaimTypes.Name, $"{userWithEmail.FirstName} {userWithEmail.SecondName}"),
                new Claim(ClaimTypes.Email, userWithEmail.Email),
                new Claim(ClaimTypes.Role, userWithEmail.Role!.Name),
            };

            var token = new JwtSecurityToken(
                issuer: Constants.ISSUER,
                audience: Constants.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // test
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
