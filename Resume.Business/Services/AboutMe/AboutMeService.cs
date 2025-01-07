using Resume.Bussines.Extensions;
using Resume.Bussines.Tools;
using Resume.Data.Repositories.AboutMe;
using Resume.Data.ViewModels.AboutMe;

namespace Resume.Business.Services.AboutMe;

public class AboutMeService : IAboutMetService
{
    private readonly IAboutMeRepository _aboutMeRepository;

    public AboutMeService(IAboutMeRepository aboutMeRepository)
    {
        _aboutMeRepository = aboutMeRepository;
    }

    public async Task<AdminSiteEditAboutMeViewModel?> GetInfoAsync()
    {
        return await _aboutMeRepository.GetInfoAsync();
    }

    public async Task<AdminSiteEditAboutMeResult> UpdateAsync(AdminSiteEditAboutMeViewModel model)
    {
        var aboutme = await _aboutMeRepository.GetAsync();

        if (aboutme == null)
        {
            return AdminSiteEditAboutMeResult.aboutMeNotFound;
        }

        aboutme.FirstName = model.FirstName;
        aboutme.LastName = model.LastName;
        aboutme.Email = model.Email;
        aboutme.Mobile = model.Mobile;
        aboutme.BirthDate = model.BirthDate;
        aboutme.Location = model.Location;
        aboutme.Position = model.Position;
        aboutme.Bio = model.Bio;

        if (model.Avatar != null)
        {
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName);
            model.Avatar.AddImageToServer(imageName,SiteTools.AboutMeAvatar);

            aboutme.ImageName = imageName;
        }

        _aboutMeRepository.Update(aboutme);

        await _aboutMeRepository.SaveAsync();

        return AdminSiteEditAboutMeResult.success;
    }
}