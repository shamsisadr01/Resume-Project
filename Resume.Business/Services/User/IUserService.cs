using Resume.Data.ViewModels.User;

namespace Resume.Business.Services.User;

public interface IUserService
{
    Task<CreateUserResult> CreateAsync(CreateUserViewModels model);
}