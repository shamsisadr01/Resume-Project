using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.User;
using Resume.Data.ViewModels.User;

namespace Resume.Web.Areas.Admin.Controllers;

public class UserController : AdminBaseController
{
    #region Fields

    private readonly IUserService _userService;

    #endregion


    #region Constructor

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    #endregion


    #region Actions

    public async Task<IActionResult> List(FilterUserViewModels filter)
    {
        var result = await _userService.FilterAsync(filter);
        return View(result);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserViewModels model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        var result = await _userService.CreateAsync(model);

        switch (result)
        {
            case CreateUserResult.Success:
                TempData[SuccessMessage] = "کاربر با موفقیت ایجاد شد.";
                return RedirectToAction("List");
                break;
            case CreateUserResult.Error:
                TempData[ErrorMessage] = "کاربر با موفقیت ایجاد نشد.";
                break;
        }

        return View(model);
    }

    public async Task<IActionResult> Update(int id)
    {
        var user = await _userService.EditAsync(id);
        if (user == null)
            return NotFound();

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Update(EditUserViewModels model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        var result = await _userService.UpdateAsync(model);

        switch (result)
        {
            case EditUserResult.Success:
                TempData[SuccessMessage] = "کاربر با موفقیت ویرایش شد.";
                return RedirectToAction("List");
                break;
            case EditUserResult.Error:
                TempData[ErrorMessage] = "کاربر با موفقیت ویرایش نشد.";
                break;
            case EditUserResult.MobileDuplicated:
                TempData[ErrorMessage] = "موبایل تکراری است.";
                break;
            case EditUserResult.EmailDuplicated:
                TempData[ErrorMessage] = "ایمیل تکراری است.";
                break;
            case EditUserResult.UserNotFound:
                TempData[ErrorMessage] = "کاربر پیدا نشد.";
                break;
        }

        return View(model);
    }


    #endregion
}