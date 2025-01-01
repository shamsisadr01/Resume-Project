namespace Resume.Data.ViewModels.User;

public class UserDetailsViewModels
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsActive { get; set; }
    public string Mobile { get; set; }
}