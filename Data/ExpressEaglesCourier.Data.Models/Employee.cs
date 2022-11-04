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
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class Employee : BaseDeletableModel<string>
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Shipments = new HashSet<Shipment>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.EmployeeFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.EmployeeMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.EmployeeLastNameMaxLength)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the home address of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerAddressMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeAddress)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the home city of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerCityMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeCity)]

        public string City { get; set; }

        /// <summary>
        /// Gets or sets the home country of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.CustomerCountryMaxLength)]
        [Comment(GlobalConstants.EntitiesConstants.HomeCountry)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the date on which the employee was hired.
        /// </summary>
        [Comment("The date on which the employee was hired.")]
        public DateTime HiredOn { get; set; }

        /// <summary>
        /// Gets or sets the employee's salary.
        /// </summary>
        [Column(TypeName = GlobalConstants.EntitiesConstants.DecimalType)]
        public decimal Salary { get; set; }

        /// <summary>
        /// Gets or sets the date on which the employee resigns / retires.
        /// </summary>
        [Comment("The date on which the employee resigns / retires.")]
        public DateTime? ResignOn { get; set; }

        /// <summary>
        /// Gets or sets the office attended by the employee.
        /// </summary>
        [Required]
        public string OfficeId { get; set; }

        public virtual Office Office { get; set; }

        /// <summary>
        /// Gets or sets the position of the employee in the company.
        /// </summary>
        [Required]
        public string PositionId { get; set; }

        public virtual Position Position { get; set; }

        /// <summary>
        /// Gets or sets collection of shipments that the employee was involved in.
        /// </summary>
        [Comment("Collection of shipments that the employee was involved in.")]
        public virtual ICollection<Shipment> Shipments { get; set; }

        /// <summary>
        /// Gets or sets the id of the Employee when he/she becomes user of the site.
        /// </summary>
        [Comment("The id of the Employee when he/she becomes user of the site.")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the company's vehicle assigned to the employee.
        /// </summary>
        [Comment("The company's vehicle assigned to the employee.")]
        public string VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
