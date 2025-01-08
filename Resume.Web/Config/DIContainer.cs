using Resume.Business.Services.AboutMe;
using Resume.Business.Services.Activity;
using Resume.Business.Services.ContactUs;
using Resume.Business.Services.User;
using Resume.Bussines.Services.Implementation;
using Resume.Bussines.Services.Interfaces;
using Resume.Data.Repositories.AboutMe;
using Resume.Data.Repositories.Activity;
using Resume.Data.Repositories.ContactUs;
using Resume.Data.Repository.User;

namespace Resume.Web.Config;

public static class DIContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        #region Repository

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IContactUsRepository, ContactUsRepository>();
        services.AddScoped<IAboutMeRepository, AboutMeRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();

        #endregion

        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IContactUsService, ContactUsService>();
        services.AddScoped<IAboutMetService, AboutMeService>();
        services.AddScoped<IActivityService, ActivityService>();


        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IViewRenderService,ViewRenderService>();

        #endregion
    }
}