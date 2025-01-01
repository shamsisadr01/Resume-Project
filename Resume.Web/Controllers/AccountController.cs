using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.User;
using Resume.Data.ViewModels.Account;

namespace Resume.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home",new {area="Admin"});
            }
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.Success:
                    var user = await _userService.GetByEmail(model.Email);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                        new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.MobilePhone,user.Mobile),
                    };

                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(principal, properties);
                    TempData[SuccessMessage] = "خوش آمدید!";

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                    break;
                case LoginResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری یافت نشد.";
                    break;
            }

            return View(model);
        }

        [HttpGet("/Logout")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
