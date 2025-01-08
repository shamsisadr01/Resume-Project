using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.Activity;

public class CreateActivityViewModel
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(350, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string Title { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(1000, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string Description { get; set; }

    [Display(Name = "ایکون")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(200, ErrorMessage = "تعداد کاراکتر وارد شده بیش از حد مجاز است.")]
    public string Icon { get; set; }
}

public enum CreateActivityResult
{
    error,success
}