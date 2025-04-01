using Resume.Data.Entities.Education;
using Resume.Data.Repositories.Education;
using Resume.Data.ViewModels.Education;

namespace Resume.Business.Services.Education;

public class EducationService : IEducationService
{
    private readonly IEducationRepository _educationRepository;

    public EducationService(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public async Task<FilterEducationViewModel> FilterAsync(FilterEducationViewModel model)
    {
        return await _educationRepository.FilterAsync(model);
    }

    public async Task<CreateEducationResult> CreateAsync(CreateEducationViewModel model)
    {
        Data.Entities.Education.Education education = new Data.Entities.Education.Education()
        {
            Title = model.Title,
            Description = model.Description,
            Start = model.Start,
            End = model.End,
            CreateDate = DateTime.Now
        };

        await _educationRepository.InsertAsync(education);
        await _educationRepository.SaveAsync();

        return CreateEducationResult.Success;
    }

    public async Task<EditEducationResult> EditAsync(EditEducationViewModel model)
    {


        var education = await _educationRepository.GetByIdAsync(model.Id);

        if (education == null)
            return EditEducationResult.NotFound;

        education.Title = model.Title;
        education.Description = model.Description;
        education.Start = model.Start;
        education.End = model.End;
        

        _educationRepository.Update(education);
        await _educationRepository.SaveAsync();

        return EditEducationResult.Success;
    }

    public async Task<EditEducationViewModel> GetForEditByIdAsync(int id)
    {
        var e = await _educationRepository.GetByIdAsync(id);

        if (e == null)
            return new EditEducationViewModel();

        return new EditEducationViewModel()
        {
            Title = e.Title,
            Description = e.Description,
            Start = e.Start,
            End = e.End,
            Id = e.Id
        };
    }
}