using Resume.Data.ViewModels.ContactUs;

namespace Resume.Business.Services.ContactUs;

public interface IContactUsService
{
    Task<FilterContactUsViewModels> FilterAsync(FilterContactUsViewModels model);
    Task<CreateContactUsResult> CreateContactUsAsync(CreateContactUsViewModels model);

    Task<ContactUsDetailViewModels> GetByIdAsync(int id);

    Task<AnswerResult> AnswerAsync(ContactUsDetailViewModels model);

}