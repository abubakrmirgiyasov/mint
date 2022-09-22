using Microsoft.EntityFrameworkCore;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;

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
            .Include(x => x.Role)
            .ToListAsync();
        return users;
    }

    public async Task<User> GetUserByIdAync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        return user ?? throw new Exception("Пользователь не найден");
    }

    public async Task<User> GetUserByEmailAync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user ?? throw new Exception("Пользователь не найден");
    }

    public async Task<User> GetUserByPhoneAync(long phone)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        return user ?? throw new Exception("Пользователь не найден");
    }

    public async Task<User> AddUserWithPhoneAync(User user)
    {
        _ = await GetUserByPhoneAync(user.Phone) ?? throw new Exception("Пользователь с таким телефоном существует");

        user.Password = Encrypt.EncodePassword(user.Password);
        user.ConfirmedPassword = Encrypt.EncodePassword(user.ConfirmedPassword);
        
        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
        user.RoleId = role!.Id;

        var photos = await _context.AddPhotoAsync(user.Files!);
        user.Photos = photos;

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

    public async Task<User> GetSigninUser(string login, string password)
    {
        var encodedPassword = Encrypt.EncodePassword(password);
        var userWithEmail = await _context.Users
            .Include(x => x.Role)
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
        return new User();
    }

    public Task<User> SigninAsync(User user)
    {
        throw new NotImplementedException();
    }
}
