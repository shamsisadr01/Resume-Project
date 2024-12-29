using Microsoft.AspNetCore.Mvc;

namespace Resume.Web.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    #region Actions

    // GET
    public IActionResult Index()
    {
        return View();
    }

    #endregion
}