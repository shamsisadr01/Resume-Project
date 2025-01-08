using Microsoft.AspNetCore.Mvc;
using Resume.Data.Repositories.Activity;
using Resume.Data.ViewModels.Activity;

namespace Resume.Business.Services.Activity;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<FilterActivityViewModels> FilterAsync(FilterActivityViewModels model)
    {
        return await _activityRepository.FilterAsync(model);
    }

    public async Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model)
    {
        var activit = new Data.Entities.Activity.Activity()
        {
            Description = model.Description,
            Title = model.Title,
            Icon = model.Icon,
            CreateDate = DateTime.Now
        };

        await _activityRepository.InsertAsync(activit);

        await _activityRepository.Save();

        return CreateActivityResult.success;
    }

    public async Task<EditActivityResult> UpdateAsync(EditActivityViewModel model)
    {
        var activity = await _activityRepository.GetByID(model.ID);

        if (activity == null)
        {
            return EditActivityResult.notFound;
        }

        activity.Description = model.Description;
        activity.Title = model.Title;
        activity.Icon = model.Icon;

        _activityRepository.Update(activity);
        await _activityRepository.Save();

        return EditActivityResult.success;
    }

    public async Task<EditActivityViewModel?> GetInfoByID(int id)
    {
        return await _activityRepository.GetInfoByID(id);
    }

    public async Task<List<ActivityDetailsViewModels>> GetAllEnfo()
    {
        return await _activityRepository.GetAllEnfo();
    }
}