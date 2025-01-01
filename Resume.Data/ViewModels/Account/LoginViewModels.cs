using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.Account;

public class LoginViewModels
{
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [EmailAddress(ErrorMessage = "لطفا فرمت {0} معتبر وارد کنید.")]
    public string Email { get; set; }

    [Display(Name = "رمز")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}


public enum LoginResult
{
    Success,Error,UserNotFound
}