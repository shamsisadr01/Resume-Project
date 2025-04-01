using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using Resume.Data.ViewModels.Education;

namespace Resume.Data.Repositories.Education;

public class EducationRepository : IEducationRepository
{
    private readonly ResumeContext _context;

    public EducationRepository(ResumeContext context)
    {
        _context = context;
    }

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        var query = _context.Education.AsQueryable();

        if (!string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(e => e.Title.Contains(model.Title));
        }

        if (model.Start.HasValue)
        {
            query = query.Where(e => e.Start >= model.Start.Value);
        }

        if (model.End.HasValue)
        {
            query = query.Where(e => e.End <= model.End.Value);
        }

        query = query.OrderByDescending(e => e.CreateDate);

        await model.Paging(query.Select(e => new EducationViewModel()
        {
            Title = e.Title,
            Description = e.Description,
            Start = e.Start,
            End = e.End,
            Id = e.Id,
            CreateDate = e.CreateDate
        }));

        return model;
    }

    public async Task InsertAsync(Entities.Education.Education education)
    {
        await _context.Education.AddAsync(education);
    }

    public void Update(Entities.Education.Education education)
    {
        _context.Education.Update(education);
    }

    public async Task SaveAsync()
    {
       await _context.SaveChangesAsync();
    }

    public async Task<Entities.Education.Education> GetByIdAsync(int id)
    {
        return await _context.Education.FirstOrDefaultAsync(e => e.Id == id);
    }
}