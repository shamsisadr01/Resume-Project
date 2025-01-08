using Resume.Data.Entities.Common;

namespace Resume.Data.Entities.Activity;

public class Activity : BaseEntity<int>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Icon { get; set; }
}