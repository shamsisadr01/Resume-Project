using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using System.Reflection;

namespace Resume.Data.Repository.User;

public class UserRepository : IUserRepository
{
    private readonly ResumeContext _context;

    public UserRepository(ResumeContext context)
    {
        _context = context;
    }

    public async Task InsertAsync(Entities.User.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.User.User> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> DuplicatedEmailAsync(int id, string email)
    {
        return await _context.Users.AnyAsync(user => user.Mobile.Contains(email) && user.Id != id);
    }

    public async Task<bool> DuplicatedMobileAsync(int id, string mobile)
    {
        return await _context.Users.AnyAsync(user => user.Mobile.Contains(mobile) && user.Id != id);
    }

    public void Update(Entities.User.User user)
    {
        _context.Users.Update(user);
    }
}