// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;

    public class Vehicle : BaseDeletableModel<string>
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets model of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.VehicleModelNameMaxLenght)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the registration / plate number of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.VehiclePlateNumberMaxLenght)]
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets the vehicle's driver from the employees.
        /// </summary>
        [Required]
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
