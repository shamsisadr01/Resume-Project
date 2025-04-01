using Resume.Data.Entities.Common;

namespace Resume.Data.Entities.Education;

public class Education : BaseEntity<int>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateOnly Start { get; set; }
    public DateOnly? End { get; set; }
}