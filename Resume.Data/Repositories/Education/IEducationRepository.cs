using Resume.Data.ViewModels.Education;

namespace Resume.Data.Repositories.Education;

public interface IEducationRepository
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task InsertAsync(Entities.Education.Education education);

    void Update(Entities.Education.Education education);

    Task SaveAsync();

    Task<Entities.Education.Education> GetByIdAsync(int id);
}