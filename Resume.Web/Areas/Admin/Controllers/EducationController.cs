using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Education;
using Resume.Data.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }


        public async Task<IActionResult> List(FilterEducationViewModel filter)
        {
            var model = await _educationService.FilterAsync(filter);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _educationService.CreateAsync(model);

            switch (result)
            {
                case CreateEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction(nameof(List));
                case CreateEducationResult.Error:
                    TempData[ErrorMessage] = "عملیات با موفقیت انجام نشد.";
                    break;
            }

            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var model = await _educationService.GetForEditByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEducationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _educationService.EditAsync(model);

            switch (result)
            {
                case EditEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction(nameof(List));
                case EditEducationResult.Error:
                    TempData[ErrorMessage] = "عملیات با موفقیت انجام نشد.";
                    break;

                case EditEducationResult.NotFound:
                    TempData[ErrorMessage] = "تحصیلات پیدا نشد.";
                    break;
            }

            return View(model);
        }
    }
}
