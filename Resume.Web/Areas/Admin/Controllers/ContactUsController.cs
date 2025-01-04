using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.ContactUs;
using Resume.Data.ViewModels.ContactUs;
using Resume.Web.Areas.Admin.Controllers;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public async Task<IActionResult> List(FilterContactUsViewModels filter)
        {
            var model = await _contactUsService.FilterAsync(filter);
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var conatctUs = await _contactUsService.GetByIdAsync(id);
            if (conatctUs == null)
            {
                return NotFound();
            }

            return View(conatctUs);
        }

        [HttpPost]
        public async Task<IActionResult> Details(ContactUsDetailViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _contactUsService.AnswerAsync(model);
            switch (result)
            {
                case AnswerResult.success:
                    TempData[SuccessMessage] = "پاسخ برای این تماس با ما ارسال شد.";
                    return RedirectToAction("List");

                case AnswerResult.NotFound:
                    TempData[ErrorMessage] = "تماس با ما پیدا نشد.";
                    break;

                case AnswerResult.answerIsNull:
                    TempData[ErrorMessage] = "متن پاسخ خالی است.";
                    break;

            }

            return View(model);
        }
    }
}
