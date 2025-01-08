using System.ComponentModel.DataAnnotations;
using Resume.DAL.ViewModels.Common;

namespace Resume.Data.ViewModels.Activity;

public class FilterActivityViewModels : BasePaging<ActivityDetailsViewModels>
{
    [Display(Name = "عنوان")]
    public string? Title { get; set; }
}