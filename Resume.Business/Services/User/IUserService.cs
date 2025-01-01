using Resume.Data.ViewModels.Account;
using Resume.Data.ViewModels.User;

namespace Resume.Business.Services.User;

public interface IUserService
{
    Task<CreateUserResult> CreateAsync(CreateUserViewModels model);
    Task<EditUserResult> UpdateAsync(EditUserViewModels model);

    Task<EditUserViewModels> EditAsync(int id);

    Task<FilterUserViewModels> FilterAsync(FilterUserViewModels model);

    Task<LoginResult> LoginAsync(LoginViewModels model);

    Task<Data.Entities.User.User> GetByEmail(string email);
}