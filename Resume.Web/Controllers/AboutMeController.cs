using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.AboutMe;

namespace Resume.Web.Controllers
{
    public class AboutMeController : SiteBaseController
    {
        private readonly IAboutMetService _aboutMetService;

        public AboutMeController(IAboutMetService aboutMetService)
        {
            _aboutMetService = aboutMetService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            var model = await _aboutMetService.GetInfoAsync();
            return View(model);
        }
    }
}
