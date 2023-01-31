// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Customer : BaseDeletableModel<string>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SentShipments = new HashSet<Shipment>();
            this.ReceivedShipments = new HashSet<Shipment>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(MiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment(HomeAddress)]
        public string Address { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment(HomeCity)]
        public string City { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        [Comment(HomeCountry)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the company should shipment is ordered by a company.
        /// </summary>
        [MaxLength(CompanyNameMaxLength)]
        [Comment("The name of the company should shipment is ordered by a company")]
        public string CompanyName { get; set; }

        [MaxLength(PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets collection of customer's sent shipments.
        /// </summary>
        [Comment("Collection of customer's sent shipments.")]
        [InverseProperty(nameof(Shipment.Sender))]
        public virtual ICollection<Shipment> SentShipments { get; set; }

        /// <summary>
        /// Gets or sets collection of customer's received shipments.
        /// </summary>
        [Comment("Collection of customer's received shipments.")]
        [InverseProperty(nameof(Shipment.Receiver))]
        public virtual ICollection<Shipment> ReceivedShipments { get; set; }

        /// <summary>
        /// Gets or sets the Customer should he/she becomes user of the site.
        /// </summary>
        [Comment("The Id of the Customer should he/she become user of the site")]

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
