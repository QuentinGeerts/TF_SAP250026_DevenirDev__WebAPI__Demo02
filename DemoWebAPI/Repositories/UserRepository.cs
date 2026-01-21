using DemoWebAPI.Data;
using DemoWebAPI.Data.Entities;
using DemoWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Repositories;

public class UserRepository (DataContext _context) : IUserRepository
{
    public async Task CreateAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistingByEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
