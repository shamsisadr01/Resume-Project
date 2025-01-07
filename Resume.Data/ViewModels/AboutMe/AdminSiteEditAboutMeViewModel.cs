using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Resume.Data.ViewModels.AboutMe;

public class AdminSiteEditAboutMeViewModel
{
    public int Id { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? LastName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    [EmailAddress(ErrorMessage = "لطفا فرمت {0} معتبر وارد کنید.")]
    public string? Email { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(15, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? Mobile { get; set; }

    [Display(Name = "تاریخ تولد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public DateOnly? BirthDate { get; set; }

    [Display(Name = "آدرس")]
    [MaxLength(300, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? Location { get; set; }

    [Display(Name = "سمت")]
    [MaxLength(100, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? Position { get; set; }

    [Display(Name = "بیوگرافی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string? Bio { get; set; }

    [Display(Name = "نام عکس")]
    public string? ImageName { get; set; }

    [Display(Name = "پروفایل")]
    public IFormFile? Avatar { get; set; }
}

public enum AdminSiteEditAboutMeResult
{
    success,error,aboutMeNotFound
}