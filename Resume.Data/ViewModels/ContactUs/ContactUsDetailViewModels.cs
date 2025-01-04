using Resume.DAL.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace Resume.Data.ViewModels.ContactUs;

public class ContactUsDetailViewModels 
{
    public int ContactUsId { get; set; }
    public DateTime CreateDate { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Description { get; set; }


    [Display(Name = "پاسخ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    public string? Answer { get; set; }

    public string? Title { get; set; }
}

public enum AnswerResult
{
    success,NotFound,Error,
    answerIsNull
}