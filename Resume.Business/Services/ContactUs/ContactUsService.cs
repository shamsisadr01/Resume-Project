using Microsoft.EntityFrameworkCore;
using Resume.Bussines.Services.Interfaces;
using Resume.Data.Repositories.ContactUs;
using Resume.Data.ViewModels.ContactUs;

namespace Resume.Business.Services.ContactUs;

public class ContactUsService : IContactUsService
{
    private readonly IContactUsRepository _contactUsRepository;
   // private readonly IViewRenderService _viewRenderService;
    private readonly IEmailService _emailService;

    public ContactUsService(IContactUsRepository contactUsRepository, IEmailService emailService)
    {
        _contactUsRepository = contactUsRepository;
       // _viewRenderService = viewRenderService;
        _emailService = emailService;
    }

    public async Task<FilterContactUsViewModels> FilterAsync(FilterContactUsViewModels model)
    {
        return await _contactUsRepository.FilterAsync(model);
    }

    public async Task<CreateContactUsResult> CreateContactUsAsync(CreateContactUsViewModels model)
    {
        Data.Entities.ContactUs.ContactUs contactUs = new Data.Entities.ContactUs.ContactUs()
        {
            Answer = null,
            Description = model.Description,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Title = model.Title
        };

        await _contactUsRepository.InsertAsync(contactUs);

        await _contactUsRepository.SaveAsync();

        return CreateContactUsResult.Success;
    }

    public async Task<ContactUsDetailViewModels> GetByIdAsync(int id)
    {
        return await _contactUsRepository.GetInfoByIdAsync(id);
    }

 

    public async Task<AnswerResult> AnswerAsync(ContactUsDetailViewModels model)
    {
        var contactUs = await _contactUsRepository.GetByIdAsync(model.ContactUsId);

        if (contactUs == null)
            return AnswerResult.NotFound;

        if (string.IsNullOrEmpty(model.Answer))
            return AnswerResult.answerIsNull;

        contactUs.Answer = model.Answer;

        _contactUsRepository.Update(contactUs);
        await _contactUsRepository.SaveAsync();

       // string body = await _viewRenderService.RenderToStringAsync("Emails/AnswerContactUs", model);
        //await _emailService.SendEmail(contactUs.Email, "پاسخ به تماس با ما", body);

        return AnswerResult.success;
    }
}