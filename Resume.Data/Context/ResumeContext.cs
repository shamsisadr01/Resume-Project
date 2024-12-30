using Microsoft.EntityFrameworkCore;
using Resume.Data.Entities.User;

namespace Resume.Data.Context;

public class ResumeContext : DbContext
{
    #region Constructor

    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {

    }

    #endregion

    #region DBSets

    public DbSet<User> Users { get; set; }

    #endregion
}