// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class Customer : BaseDeletableModel<string>
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Shipments = new HashSet<Shipment>();
            this.Employees = new HashSet<Employee>();
            this.ProvidedFeedbacks = new HashSet<Feedback>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(GlobalConstants.EntityConstants.CustomerMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerAddressMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeAddress)]
        public string Address { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerCityMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeCity)]
        public string City { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerCountryMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeCountry)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the company should shipment is ordered by a company.
        /// </summary>
        [MaxLength(GlobalConstants.EntityConstants.CompanyNameMaxLength)]
        [Comment("The name of the company should shipment is ordered by a company")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets collection of customer's shipments.
        /// </summary>
        public virtual ICollection<Shipment> Shipments { get; set; }

        /// <summary>
        /// Gets or sets a collection of employees that served the customer.
        /// </summary>
        [Comment("The employees that served the customer")]
        public virtual ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the provided feedback, recommendations, complains by the customer.
        /// </summary>
        [Comment("Provided feedback, recommendations, complains by the customer")]
        public virtual ICollection<Feedback> ProvidedFeedbacks { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Customer should he/she becomes user of the site.
        /// </summary>
        [Comment("The Id of the Customer should he/she become users of the site")]

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
