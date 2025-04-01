using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.Education;

public class CreateEducationViewModel
{

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(150, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string Title { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(800, ErrorMessage = "تعداد کاراکتر وارد شده بیشتر از حد مجاز است.")]
    public string Description { get; set; }

    [Display(Name = "تاریخ تا")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public DateOnly Start { get; set; }

    [Display(Name = "تاریخ از")]
    public DateOnly? End { get; set; }
}

public enum CreateEducationResult
{
    Success, Error
}