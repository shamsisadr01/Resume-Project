using Resume.Data.Entities.Common;

namespace Resume.Data.Entities.ContactUs;

public class ContactUs : BaseEntity<int>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string? Answer { get; set; }

    public string Title { get; set; }
}