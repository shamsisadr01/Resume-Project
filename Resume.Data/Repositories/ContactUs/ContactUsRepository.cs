using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using Resume.Data.Entities.ContactUs;
using Resume.Data.ViewModels.ContactUs;

namespace Resume.Data.Repositories.ContactUs;

public class ContactUsRepository : IContactUsRepository
{
    private readonly ResumeContext _context;

    public ContactUsRepository(ResumeContext context)
    {
        _context = context;
    }

    public async Task<FilterContactUsViewModels> FilterAsync(FilterContactUsViewModels model)
    {
        var query = _context.ContactUs.AsQueryable();

        if (string.IsNullOrEmpty(model.FirstName))
        {
            query = query.Where(contactUs => EF.Functions.Like(contactUs.FirstName, $"%{model.FirstName}%"));
        }

        if (string.IsNullOrEmpty(model.LastName))
        {
            query = query.Where(contactUs => EF.Functions.Like(contactUs.LastName, $"%{model.LastName}%"));
        }

        if (string.IsNullOrEmpty(model.Email))
        {
            query = query.Where(contactUs => EF.Functions.Like(contactUs.Email, $"%{model.Email}%"));
        }

        if (string.IsNullOrEmpty(model.Mobile))
        {
            query = query.Where(contactUs => EF.Functions.Like(contactUs.PhoneNumber, $"%{model.Mobile}%"));
        }

        if (string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(contactUs => EF.Functions.Like(contactUs.Title, $"%{model.Title}%"));
        }

        switch (model.AnswerStatus)
        {
            case FilterContactUsAnswerStatus.All:
                break;
            case FilterContactUsAnswerStatus.Answer:
                query = query.Where(contactUs => contactUs.Answer != null);
                break;
            case FilterContactUsAnswerStatus.NotAnswer:
                query = query.Where(contactUs => contactUs.Answer == null);
                break;
        }

        query = query.OrderByDescending(c => c.CreateDate);

        model.Paging(query.Select(contactUs=> new ContactUsDetailViewModels()
        {
            Email = contactUs.Email,
            FirstName = contactUs.FirstName,
            LastName = contactUs.LastName,
            Title = contactUs.Title,
            Description = contactUs.Description,
            PhoneNumber = contactUs.PhoneNumber,
            Answer = contactUs.Answer,
            ContactUsId = contactUs.Id,
            CreateDate = contactUs.CreateDate
        }));

        return model;
    }

    public async Task InsertAsync(Entities.ContactUs.ContactUs contactUs)
    {
        await _context.ContactUs.AddAsync(contactUs);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<ContactUsDetailViewModels> GetInfoByIdAsync(int id)
    {
        return await _context.ContactUs.Select(c => new ContactUsDetailViewModels()
        {
            Email = c.Email,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Title = c.Title,
            Description = c.Description,
            PhoneNumber = c.PhoneNumber,
            Answer = c.Answer,
            ContactUsId = c.Id,
            CreateDate = c.CreateDate
        }).FirstOrDefaultAsync(c=>c.ContactUsId == id);
    }

    public async void Update(Entities.ContactUs.ContactUs contactUs)
    {
        _context.ContactUs.Update(contactUs);
    }

    public async Task<Data.Entities.ContactUs.ContactUs> GetByIdAsync(int id)
    {
        return await _context.ContactUs
            .FirstOrDefaultAsync(contactUs => contactUs.Id == id);
    }
}