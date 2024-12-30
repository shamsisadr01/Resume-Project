using Resume.Business.Services.User;
using Resume.Data.Repository.User;

namespace Resume.Web.Config;

public static class DIContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        #region Repository

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region Services

        services.AddScoped<IUserService, UserService>();

        #endregion
    }
}