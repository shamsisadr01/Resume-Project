namespace Resume.Data.Entities.User;

public class User
{
    #region Properties

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }
    public string Mobile { get; set; }

    public DateTime RegisterDate { get; set; }

    #endregion
}