using System.ComponentModel;
using Resume.DAL.ViewModels.Common;

namespace Resume.Data.ViewModels.Education;

public class FilterEducationViewModel : BasePaging<EducationViewModel>
{
    [DisplayName("عنوان")]
    public string? Title { get; set; }

    [DisplayName("تاریخ از")]
    public DateOnly? Start { get; set; }

    [DisplayName("تاریخ تا")]
    public DateOnly? End { get; set; }
}