using Microsoft.EntityFrameworkCore;
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
        return user ?? throw new Exception("User is not found.");
    }

    public async Task<User> GetUserByEmailAync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return user ?? throw new Exception("User is not found.");
    }

    public async Task<User> GetUserByPhoneAync(long phone)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Phone == phone);
        return user ?? throw new Exception("User is not found.");
    }

    public Task<User> AddUserAync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUserAsync(User id)
    {
        throw new NotImplementedException();
    }
}
