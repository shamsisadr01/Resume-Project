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

    public async Task<IActionResult> List()
    {
        return View();
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
                break;
            case CreateUserResult.Error:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return View();
    }

    public async Task<IActionResult> Update(int id)
    {
        var user = await _userService.EditAsync(id);
        if (user == null)
            return NotFound();

        return View();
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
                break;
            case EditUserResult.Error:
                break;
            case EditUserResult.MobileDuplicated:
                break;
            case EditUserResult.EmailDuplicated:
                break;
            case EditUserResult.UserNotFound:
                break;
        }

        return View();
    }


    #endregion
}