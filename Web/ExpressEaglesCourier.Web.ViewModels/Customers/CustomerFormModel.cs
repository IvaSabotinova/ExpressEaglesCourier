namespace ExpressEaglesCourier.Web.ViewModels.Customers
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class CustomerFormModel : IMapFrom<Customer>
    {
        public string Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.FirstName)]
        public string FirstName { get; set; }

        [StringLength(MiddleNameMaxLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.MiddleName)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.LastName)]
        public string LastName { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Comment(HomeAddress)]
        public string Address { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        [Comment(HomeCity)]
        public string City { get; set; }

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CityNameMinLength)]
        [Comment(HomeCountry)]
        public string Country { get; set; }

        [StringLength(CompanyNameMaxLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.CompanyName)]
        public string CompanyName { get; set; }

        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Display(Name = GlobalConstants.ViewModelConstants.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
