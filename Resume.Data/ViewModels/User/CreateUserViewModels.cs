using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.User;

public class CreateUserViewModels
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string LastName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(350,ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string Email { get; set; }

    [Display(Name = "رمز")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string Password { get; set; }

    [Display(Name = "فعال است؟")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public bool IsActive { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string Mobile { get; set; }
}

public enum CreateUserResult
{
    Success,Error
}