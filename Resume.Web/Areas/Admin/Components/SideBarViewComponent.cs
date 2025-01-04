using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.User;
using Resume.Bussines.Extensions;

namespace Resume.Web.Areas.Admin.Components;

public class SideBarViewComponent : ViewComponent
{
    private readonly IUserService _userService;

    public SideBarViewComponent(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userService.GetInformationAsync(User.GetUserId());
        return View("SideBar",user);
    }



}