namespace ExpressEaglesCourier.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public class EmployeeFormModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.FirstName)]
        public string FirstName { get; set; }

        [StringLength(MiddleNameMaxLength)]
        [Display(Name = MiddleNameEmployee)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.LastName)]
        public string LastName { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = HomeAddress)]
        public string Address { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        [Display(Name = HomeCity)]

        public string City { get; set; }

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        [Display(Name = HomeCountry)]
        public string Country { get; set; }

        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Display(Name = GlobalConstants.ViewModelConstants.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = HireOnDate)]
        public DateTime HiredOn { get; set; }

        [Display(Name = SalaryEmployee)]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ConvertValueInInvariantCulture = true)]
        public decimal Salary { get; set; }

        [Display(Name = ResignOnDate)]
        public DateTime? ResignOn { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int OfficeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Offices { get; set; } = new List<KeyValuePair<string, string>>();

        [Required(ErrorMessage = "The field is required")]
        public int PositionId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Positions { get; set; } = new List<KeyValuePair<string, string>>();

        public int? VehicleId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Vehicles { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
