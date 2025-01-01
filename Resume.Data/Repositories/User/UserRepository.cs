using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using System.Reflection;
using Resume.Data.ViewModels.User;

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

    public async Task<FilterUserViewModels> FilterAsync(FilterUserViewModels model)
    {
        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model.Email))
        {
            query = query.Where(user => user.Email.Contains(model.Email));
        }

        if (!string.IsNullOrWhiteSpace(model.Mobile))
        {
            query = query.Where(user => user.Mobile.Contains(model.Mobile));
        }

        await model.Paging(query.Select(user=> new UserDetailsViewModels()
        {
            Mobile = user.Mobile,
            Email = user.Email,
            Id = user.Id,
            IsActive = user.IsActive,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreateDate = user.CreateDate
        }));

        return model;

    }

    public async Task<Entities.User.User> GetUserByEmail(string Email)
    {
        return await _context.Users.FirstOrDefaultAsync(user=>user.Email.Contains(Email));
    }
}