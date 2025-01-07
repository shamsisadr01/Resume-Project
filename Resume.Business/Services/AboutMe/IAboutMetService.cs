using Resume.Data.ViewModels.AboutMe;

namespace Resume.Business.Services.AboutMe;

public interface IAboutMetService
{
    Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync();

    Task<AdminSiteEditAboutMeResult> UpdateAsync(AdminSiteEditAboutMeViewModel model);
}