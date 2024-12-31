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

        return View();
    }

    public async Task<IActionResult> Update(int id)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(EditUserViewModels model)
    {
        if (ModelState.IsValid == false)
        {
            return View(model);
        }

        return View();
    }


    #endregion
}