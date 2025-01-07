using Resume.Data.Entities.Common;

namespace Resume.Data.Entities.AboutMe;

public class AboutMe : BaseEntity<int>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Location { get; set; }

    public string? Position { get; set; }

    public string? Bio { get; set; }

    public string ImageName { get; set; }
}