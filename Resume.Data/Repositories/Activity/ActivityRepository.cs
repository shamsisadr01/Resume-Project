using Microsoft.EntityFrameworkCore;
using Resume.Data.Context;
using Resume.Data.ViewModels.Activity;
using Resume.Data.ViewModels.User;

namespace Resume.Data.Repositories.Activity;

public class ActivityRepository : IActivityRepository
{
    private readonly ResumeContext _context;

    public ActivityRepository(ResumeContext context)
    {
        _context = context;
    }

    public async Task<FilterActivityViewModels> FilterAsync(FilterActivityViewModels model)
    {
        var query = _context.Activity.AsQueryable();

        if (!string.IsNullOrEmpty(model.Title))
        {
            query = query.Where(a => EF.Functions.Like(a.Title,$"%{model.Title}%"));
        }

        query = query.OrderByDescending(a => a.CreateDate);

        await model.Paging(query.Select(a=>new ActivityDetailsViewModels()
        {
            Title = a.Title,
            Description = a.Description,
            ActivityId = a.Id,
            CreatedDate = a.CreateDate,
            Icon = a.Icon
        }));

        return model;
    }

    public async Task InsertAsync(Entities.Activity.Activity activity)
    {
        await _context.Activity.AddAsync(activity);
    }

    public void Update(Entities.Activity.Activity activity)
    {
        _context.Activity.Update(activity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<EditActivityViewModel?> GetInfoByID(int id)
    {
        return await _context.Activity.Where(a => a.Id == id).Select(a=>new EditActivityViewModel()
        {
            Title = a.Title,
            Description = a.Description,
            Icon = a.Icon,
            ID = a.Id
        }).FirstOrDefaultAsync();
    }

    public async Task<Entities.Activity.Activity?> GetByID(int id)
    {
        return await _context.Activity.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<ActivityDetailsViewModels>> GetAllEnfo()
    {
        return _context.Activity.Select(a => new ActivityDetailsViewModels()
        {
            Title = a.Title,
            Description = a.Description,
            Icon = a.Icon,
            CreatedDate = a.CreateDate,
            ActivityId = a.Id,
        }).ToList();
    }
}