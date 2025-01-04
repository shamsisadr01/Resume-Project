using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.ContactUs;

public class CreateContactUsViewModels
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string LastName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(250, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    [EmailAddress(ErrorMessage = "لطفا فرمت {0} معتبر وارد کنید.")]
    public string Email { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(50, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string PhoneNumber { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(1000, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string Description { get; set; }


    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(350,ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string Title { get; set; }
}

public enum CreateContactUsResult
{
    Success,Error
}