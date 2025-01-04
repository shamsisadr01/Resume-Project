using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Resume.Data.Entities.ContactUs;
using Resume.Data.Entities.User;

namespace Resume.Data.Context;

public class ResumeContext : DbContext
{

    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {

    }


    public DbSet<User> Users { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(new User()
            {
                CreateDate = DateTime.Now,
                Email = "shamsisadr01@gmail.com",
                FirstName = "شهریار",
                LastName = "شمسی صدر",
                Id = 1,
                IsActive = true,
                Mobile = "09367806232",
                Password = "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B"
            });


        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}