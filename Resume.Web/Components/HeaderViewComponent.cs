using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.AboutMe;

namespace Resume.Web.Components;

public class HeaderViewComponent : ViewComponent
{
    private readonly IAboutMetService _aboutMetService;

    public HeaderViewComponent(IAboutMetService aboutMetService)
    {
        _aboutMetService = aboutMetService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _aboutMetService.GetInfoAsync();
        return View("Header",model);
    }

}