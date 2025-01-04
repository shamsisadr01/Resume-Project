using Resume.Data.ViewModels.ContactUs;

namespace Resume.Data.Repositories.ContactUs;

public interface IContactUsRepository
{
    Task<FilterContactUsViewModels> FilterAsync(FilterContactUsViewModels model);

    Task InsertAsync(Entities.ContactUs.ContactUs contactUs);

    Task SaveAsync();

    Task<Data.Entities.ContactUs.ContactUs> GetByIdAsync(int id);

    Task<ContactUsDetailViewModels> GetInfoByIdAsync(int id);

    void Update(Entities.ContactUs.ContactUs contactUs);
}