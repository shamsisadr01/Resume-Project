using Resume.Data.ViewModels.AboutMe;

namespace Resume.Data.Repositories.AboutMe;

public interface IAboutMeRepository
{
    Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync();
    Task<Entities.AboutMe.AboutMe> GetAsync();

    void Update(Entities.AboutMe.AboutMe aboutMe);

    Task SaveAsync();
}