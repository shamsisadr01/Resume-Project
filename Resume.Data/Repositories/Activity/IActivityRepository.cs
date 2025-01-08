using Resume.Data.ViewModels.Activity;

namespace Resume.Data.Repositories.Activity;

public interface IActivityRepository
{
    Task<FilterActivityViewModels> FilterAsync(FilterActivityViewModels model);

    Task InsertAsync(Entities.Activity.Activity activity);

    void Update(Entities.Activity.Activity activity);

    Task Save();

    Task<EditActivityViewModel?> GetInfoByID(int id);
    Task<Entities.Activity.Activity?> GetByID(int id);

    Task<List<ActivityDetailsViewModels>> GetAllEnfo();
}