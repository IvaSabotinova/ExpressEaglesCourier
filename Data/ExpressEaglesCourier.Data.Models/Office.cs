// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;

    public class Office : BaseDeletableModel<string>
    {
        public Office()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<Employee>();
            this.ReceivedFeedbacks = new HashSet<Feedback>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.OfficeAddressMaxLength)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the office.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the office.
        /// </summary>
        [Phone]
        public string FaxNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        /// <summary>
        /// Gets or sets collection of employees working in the office.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets collection of received feedback from customer.
        /// </summary>
        public virtual ICollection<Feedback> ReceivedFeedbacks { get; set; }
    }
}
