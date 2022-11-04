// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class Customer : BaseDeletableModel<string>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.SentShipments = new HashSet<Shipment>();
            this.ReceivedShipments = new HashSet<Shipment>();
            this.SenderFeedbacks = new HashSet<Feedback>();
            this.ReceiverFeedbacks = new HashSet<Feedback>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.CustomerMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerAddressMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeAddress)]
        public string Address { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerCityMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeCity)]
        public string City { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerCountryMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeCountry)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the company should shipment is ordered by a company.
        /// </summary>
        [MaxLength(GlobalConstants.EntitiesConstants.CompanyNameMaxLength)]
        [Comment("The name of the company should shipment is ordered by a company")]
        public string CompanyName { get; set; }

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
        /// Gets or sets the provided feedback, recommendations, complains by the sender customer.
        /// </summary>
        [Comment("Provided feedback, recommendations, complains by the sender customer")]
        [InverseProperty(nameof(Feedback.Sender))]
        public virtual ICollection<Feedback> SenderFeedbacks { get; set; }

        /// <summary>
        /// Gets or sets collection of the provided feedback, recommendations, complains by the receiver customer.
        /// </summary>
        [Comment("Collection of the provided feedback, recommendations, complains by the receiver customer")]
        [InverseProperty(nameof(Feedback.Receiver))]
        public virtual ICollection<Feedback> ReceiverFeedbacks { get; set; }

        /// <summary>
        /// Gets or sets the Customer should he/she becomes user of the site.
        /// </summary>
        [Comment("The Id of the Customer should he/she become user of the site")]

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
