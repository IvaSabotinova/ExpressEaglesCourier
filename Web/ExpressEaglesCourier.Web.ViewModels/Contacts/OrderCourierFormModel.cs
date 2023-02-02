namespace ExpressEaglesCourier.Web.ViewModels.Contacts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public class OrderCourierFormModel
    {
        [Required]
        [StringLength(FirstAndLastNameMaxLength, MinimumLength = FirstAndLastNameMinLength)]
        public string FirstAndLastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string PickUpAddress { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        public string PickUpCity { get; set; }

        public string ShipmentType { get; set; }

        [MaxLength(AdditionalInfoForOrder)]
        public string AdditionalInformation { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
