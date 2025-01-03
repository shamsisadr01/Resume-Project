﻿using Resume.Bussines.Security;
using Resume.Data.Repository.User;
using Resume.Data.ViewModels.Account;
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
            Password = model.Password.Trim().EncodePasswordMd5(),
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

    public async Task<LoginResult> LoginAsync(LoginViewModels model)
    {
        model.Email = model.Email.Trim().ToLower();
        var user = await _userRepository.GetUserByEmail(model.Email);
        if (user == null)
        {
            return LoginResult.UserNotFound;
        }

        string hashPassword = model.Password.Trim().EncodePasswordMd5();

        if (user.Password != hashPassword)
        {
            return LoginResult.UserNotFound;
        }

        return LoginResult.Success;
    }

    public async Task<Data.Entities.User.User> GetByEmail(string email)
    {
        email = email.Trim().ToLower();
        return await _userRepository.GetUserByEmail(email);
    }

    public async Task<UserDetailsViewModels> GetInformationAsync(int id)
    {
        var user = await _userRepository.GetUserById(id);

        if (user == null)
        {
            return null;
        }

        return new UserDetailsViewModels()
        {
            Mobile = user.Mobile,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreateDate = user.CreateDate,
            Id = user.Id,
            IsActive = user.IsActive
        };
    }
}