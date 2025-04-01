using Resume.Data.ViewModels.Education;

namespace Resume.Business.Services.Education;

public interface IEducationService
{
    Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model);

    Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model);

    Task<EditEducationResult> EditAsync(EditEducationViewModel model);

    Task<EditEducationViewModel> GetForEditByIdAsync(int id);
}