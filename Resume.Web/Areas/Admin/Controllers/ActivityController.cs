using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Activity;
using Resume.Data.ViewModels.AboutMe;
using Resume.Data.ViewModels.Activity;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task<IActionResult> List(FilterActivityViewModels filter)
        {
            var mode = await _activityService.FilterAsync(filter);
            return View(mode);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _activityService.CreateAsync(model);
            switch (result)
            {
                case CreateActivityResult.success:
                    TempData[SuccessMessage] = "فعالیت با موفقیت ساخته شد..";
                    return RedirectToAction(nameof(List));
                    break;
                case CreateActivityResult.error:
                    TempData[ErrorMessage] = "خطایی رخ داد.";
                    break;
            }
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _activityService.GetInfoByID(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Update(EditActivityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            var result = await _activityService.UpdateAsync(model);
            switch (result)
            {
                case EditActivityResult.success:
                    TempData[SuccessMessage] = "ویرایش با موفقیت انجام شد.";
                    return RedirectToAction(nameof(List));
                    break;
                case EditActivityResult.error:
                    TempData[ErrorMessage] = "ویرایش با موفقیت انجام نشد.";
                    break;
                case EditActivityResult.notFound:
                    TempData[ErrorMessage] = "فعالیتی برای ویرایش پیدا نشد.";
                    break;
            }

            return View(model);
        }
    }
}
