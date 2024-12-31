using Resume.Data.ViewModels.User;

namespace Resume.Business.Services.User;

public interface IUserService
{
    Task<CreateUserResult> CreateAsync(CreateUserViewModels model);
    Task<EditUserResult> UpdateAsync(EditUserViewModels model);

    Task<EditUserViewModels> EditAsync(int id);
}