using Resume.Data.Repository.User;
using Resume.Data.ViewModels.User;

namespace Resume.Business.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResult> CreateAsync(CreateUserViewModels model)
    {
        Data.Entities.User.User user = new Data.Entities.User.User()
        {
            CreateDate = DateTime.Now,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            Password = model.Password,
            IsActive = model.IsActive
        };

        await _userRepository.InsertAsync(user);

        await _userRepository.SaveAsync();

        return CreateUserResult.Success;
    }
}