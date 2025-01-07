using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.AboutMe;
using Resume.Data.ViewModels.AboutMe;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class AboutMeController : AdminBaseController
    {
        private readonly IAboutMetService _aboutMetService;

        public AboutMeController(IAboutMetService aboutMetService)
        {
            _aboutMetService = aboutMetService;
        }

        public async Task<IActionResult> Edit()
        {
            var aboutMe = await _aboutMetService.GetInfoAsync();
            if (aboutMe == null)
            {
                return NotFound();
            }

            return View(aboutMe);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminSiteEditAboutMeViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var result = await _aboutMetService.UpdateAsync(model);
            switch (result)
            {
                case AdminSiteEditAboutMeResult.success:
                    TempData[SuccessMessage] = "ویرایش با موفقیت انجام شد.";
                    return RedirectToAction(nameof(Edit));
                    break;
                case AdminSiteEditAboutMeResult.error:
                    TempData[ErrorMessage] = "ویرایش با موفقیت انجام نشد.";
                    break;
                case AdminSiteEditAboutMeResult.aboutMeNotFound:
                    TempData[ErrorMessage] = "درباره من پیدا نشد.";
                    break;
            }

            return View(model);
        }
    }
}
