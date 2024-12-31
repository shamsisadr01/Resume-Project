namespace Resume.Data.Repository.User;

public interface IUserRepository
{
    Task InsertAsync(Entities.User.User  user);
    Task SaveAsync();

    Task<Entities.User.User> GetUserById(int id);

    Task<bool> DuplicatedEmailAsync(int id,string email);
    Task<bool> DuplicatedMobileAsync(int id,string mobile);

    void Update(Entities.User.User user);

}