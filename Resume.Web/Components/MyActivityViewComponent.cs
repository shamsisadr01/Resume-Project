using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.AboutMe;
using Resume.Business.Services.Activity;

namespace Resume.Web.Components
{
    public class MyActivityViewComponent : ViewComponent
    {
        private readonly IActivityService _activityService;

        public MyActivityViewComponent(IActivityService activityService)
        {
            _activityService = activityService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _activityService.GetAllEnfo();
            return View("MyActivity", model);
        }
    }
}
