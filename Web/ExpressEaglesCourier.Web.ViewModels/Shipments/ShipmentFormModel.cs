namespace ExpressEaglesCourier.Web.ViewModels.Shipments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Web.Infrastructure.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class ShipmentFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TrackingNumberMaxLength, MinimumLength = TrackingNumberMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.TrackingNumber)]
        public string TrackingNumber { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.SenderFirstName)]
        public string SenderFirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.SenderLastName)]
        public string SenderLastName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Phone]
        [Display(Name = GlobalConstants.ViewModelConstants.SenderPhoneNumber)]
        public string SenderPhoneNumber { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.ReceiverFirstName)]
        public string ReceiverFirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.ReceiverLastName)]
        public string ReceiverLastName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLenght, MinimumLength = PhoneNumberMinLenght)]
        [Phone]
        [Display(Name = GlobalConstants.ViewModelConstants.ReceiverPhoneNumber)]
        public string ReceiverPhoneNumber { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.PickUpAddress)]
        public string PickUpAddress { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.PickUpTown)]
        public string PickUpTown { get; set; }

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.PickUpCountry)]
        public string PickUpCountry { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.DestinationAddress)]
        public string DestinationAddress { get; set; }

        [Required]
        [StringLength(CityNameMaxLength, MinimumLength = CityNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.DestinationTown)]
        public string DestinationTown { get; set; }

        [Required]
        [StringLength(CountryNameMaxLength, MinimumLength = CountryNameMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.DestinationCountry)]
        public string DestinationCountry { get; set; }

        [Required]
        public DeliveryType DeliveryType { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public DeliveryWay DeliveryWay { get; set; }

        [Required]
        [Range(ShipmentMinWeightInKg, ShipmentMaxWeightInKg, ConvertValueInInvariantCulture = true)]
        public double Weight { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        // ??ErrorMessage
        [MaxFileSize(30 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".webp", ".png" })]
        public IEnumerable<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}
