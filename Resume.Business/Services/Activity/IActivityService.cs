using Resume.Data.ViewModels.Activity;

namespace Resume.Business.Services.Activity;

public interface IActivityService
{
    Task<FilterActivityViewModels> FilterAsync(FilterActivityViewModels model);

    Task<CreateActivityResult> CreateAsync(CreateActivityViewModel model);

    Task<EditActivityResult> UpdateAsync(EditActivityViewModel model);

    Task<EditActivityViewModel?> GetInfoByID(int id);

    Task<List<ActivityDetailsViewModels>> GetAllEnfo();
}