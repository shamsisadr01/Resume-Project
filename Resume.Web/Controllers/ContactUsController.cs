using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.ContactUs;
using System.Threading.Tasks;
using Resume.Data.ViewModels.ContactUs;

namespace Resume.Web.Controllers
{
    public class ContactUsController : SiteBaseController
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet("/contact-us")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("/contact-us")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModels model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var result = await _contactUsService.CreateContactUsAsync(model);

            switch (result)
            {
                case CreateContactUsResult.Success:
                    TempData[SuccessMessage] = "تماس شما با موفقیت ثبت شد.";
                    return RedirectToAction("ContactUs");
                    break;
                case CreateContactUsResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است مجددا تلاش کنید.";
                    break;
            }

            return View(model);
        }
    }
}
