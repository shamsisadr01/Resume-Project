using Resume.Data.Entities.Common;

namespace Resume.Data.ViewModels.Education;

public class EducationViewModel 
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateOnly Start { get; set; }
    public DateOnly? End { get; set; }
}