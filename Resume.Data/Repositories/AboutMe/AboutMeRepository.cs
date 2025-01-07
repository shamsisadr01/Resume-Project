using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using Resume.Data.ViewModels.AboutMe;

namespace Resume.Data.Repositories.AboutMe;

public class AboutMeRepository : IAboutMeRepository
{
    private readonly ResumeContext _context;

    public AboutMeRepository(ResumeContext context)
    {
        _context = context;
    }

    public async Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync()
    {
        return await _context.AboutMe.Select(c=>new AdminSiteEditAboutMeViewModel()
        {
            Mobile = c.Mobile,
            Email = c.Email,
            FirstName = c.FirstName,
            LastName = c.LastName,
            BirthDate = c.BirthDate,
            Id = c.Id,
            Location = c.Location,
            Position = c.Position,
            Bio = c.Bio,
            ImageName = c.ImageName
        }).FirstOrDefaultAsync();
    }

    public async Task<Entities.AboutMe.AboutMe> GetAsync()
    {
        return await _context.AboutMe.FirstOrDefaultAsync();
    }

    public void Update(Entities.AboutMe.AboutMe aboutMe)
    {
        _context.AboutMe.Update(aboutMe);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}