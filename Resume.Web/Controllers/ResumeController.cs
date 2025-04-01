using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Controllers
{
    public class ResumeController : SiteBaseController
    {
        [HttpGet("/resume")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
