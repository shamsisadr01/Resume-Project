using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.Data.ViewModels.User;

public class FilterUserViewModels  : BasePaging<UserDetailsViewModels>
{
    [Display(Name = "موبایل")]
    public string? Mobile { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }
}