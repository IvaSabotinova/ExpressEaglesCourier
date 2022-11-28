// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Employee : BaseDeletableModel<string>
    {
        public Employee()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmployeesShipments = new HashSet<EmployeeShipment>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(MiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the home address of the employee.
        /// </summary>
        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment(HomeAddress)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the home city of the employee.
        /// </summary>
        [Required]
        [MaxLength(CityNameMaxLength)]
        [Comment(HomeCity)]

        public string City { get; set; }

        /// <summary>
        /// Gets or sets the home country of the employee.
        /// </summary>
        [Required]
        [MaxLength(CountryNameMaxLength)]
        [Comment(HomeCountry)]
        public string Country { get; set; }

        [MaxLength(PhoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date on which the employee was hired.
        /// </summary>
        [Comment("The date on which the employee was hired.")]
        public DateTime HiredOn { get; set; }

        /// <summary>
        /// Gets or sets the employee's salary.
        /// </summary>
        [Column(TypeName = DecimalType)]
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
        public int OfficeId { get; set; }

        public virtual Office Office { get; set; }

        /// <summary>
        /// Gets or sets the position of the employee in the company.
        /// </summary>
        [Required]
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        /// <summary>
        /// Gets or sets collection of shipments that the employee was involved in.
        /// </summary>
        [Comment("Collection of shipments that the employee was involved in.")]
        public virtual ICollection<EmployeeShipment> EmployeesShipments { get; set; }

        /// <summary>
        /// Gets or sets the id of the Employee when he/she becomes user of the site.
        /// </summary>
        [Comment("The id of the Employee when he/she becomes user of the site.")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the vehicle used by the employee courier.
        /// </summary>
        [Comment("The vehicle used by the employee courier.")]
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
