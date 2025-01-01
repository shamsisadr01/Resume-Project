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
            Email = model.Email.Trim().ToLower(),
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

    public async Task<EditUserResult> UpdateAsync(EditUserViewModels model)
    {
        var user = await _userRepository.GetUserById(model.ID);
        if (user == null)
            return EditUserResult.UserNotFound;

        if (await _userRepository.DuplicatedEmailAsync(user.Id, user.Email.ToLower().Trim()))
            return EditUserResult.EmailDuplicated;

        if (await _userRepository.DuplicatedMobileAsync(user.Id, user.Mobile))
            return EditUserResult.MobileDuplicated;

        user.Mobile = model.Mobile;
        user.Email = model.Email;
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.IsActive = model.IsActive;

        _userRepository.Update(user);

        await _userRepository.SaveAsync();
        return EditUserResult.Success;
    }

    public async Task<EditUserViewModels> EditAsync(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user == null)
        {
            return null;
        }

        return new EditUserViewModels()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Mobile = user.Mobile,
            IsActive = user.IsActive,
            ID = user.Id
        };
    }

    public async Task<FilterUserViewModels> FilterAsync(FilterUserViewModels model)
    {
        return await _userRepository.FilterAsync(model);
    }
}