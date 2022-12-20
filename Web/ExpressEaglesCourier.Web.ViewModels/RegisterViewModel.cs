namespace ExpressEaglesCourier.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLenght, MinimumLength = EmailMinLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Phone]
        [StringLength(PhoneNumberMaxLenght)]

        public string TelephoneNumber { get; set; }
    }
}
