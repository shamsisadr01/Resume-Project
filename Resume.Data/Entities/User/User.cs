using Resume.Data.Entities.Common;

namespace Resume.Data.Entities.User;

public class User : BaseEntity<int>
{
    #region Properties

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }
    public string Mobile { get; set; }

    #endregion
}