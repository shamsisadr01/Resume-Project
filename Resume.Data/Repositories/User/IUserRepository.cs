namespace Resume.Data.Repository.User;

public interface IUserRepository
{
    Task InsertAsync(Entities.User.User  user);
    Task SaveAsync();
}