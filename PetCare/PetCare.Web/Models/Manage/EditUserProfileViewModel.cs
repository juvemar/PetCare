namespace PetCare.Web.Models.Manage
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using Common;

    public class EditUserProfileViewModel
    {
        public HttpPostedFileBase ProfilePicture { get; set; }
        
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "UserName")]
        [UIHint("UsernameInputForm")]
        public string UserName { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        [UIHint("FirstNameInputForm")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        [UIHint("LastNameInputForm")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Phone Number (+359)")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "The field Phone Number must be between 6 and 10 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The field Phone Number must consist only digits.")]
        [UIHint("PhoneNumberInputForm")]
        public string PhoneNumber { get; set; }

        [UIHint("SergeryLocationInputForm")]
        public string SergeryLocation { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [UIHint("EmailInputForm")]
        public string Email { get; set; }
    }
}