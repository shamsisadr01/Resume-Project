using Resume.Data.Context;

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
}