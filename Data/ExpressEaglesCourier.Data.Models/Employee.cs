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
            this.Customers = new HashSet<Customer>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.EmployeeFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(GlobalConstants.EntityConstants.EmployeeMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.EmployeeLastNameMaxLength)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the home address of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerAddressMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeAddress)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the home city of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerCityMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeCity)]

        public string City { get; set; }

        /// <summary>
        /// Gets or sets the home country of the employee.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CustomerCountryMaxLength)]
        [Comment(GlobalConstants.EntityConstants.HomeCountry)]
        public string Country { get; set; }

        public DateTime HiredOn { get; set; }

        /// <summary>
        /// Gets or sets the employee's salary.
        /// </summary>
        [Column(TypeName = GlobalConstants.EntityConstants.DecimalType)]
        public decimal Salary { get; set; }

       /// <summary>
       /// Gets or sets the date on which the employee resigns / retires.
       /// </summary>
        public DateTime? ResignOn { get; set; }

        /// <summary>
        /// Gets or sets the office where the employees works.
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
        /// Gets or sets collection of shipments that the employee was responsible for.
        /// </summary>
        public virtual ICollection<Shipment> Shipments { get; set; }

        /// <summary>
        /// Gets or sets collection of customers served by the employee.
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Employee when he/she becomes user of the site.
        /// </summary>
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the Id of a company's vehicle should employee's position requires usage of one.
        /// </summary>
        public string VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
