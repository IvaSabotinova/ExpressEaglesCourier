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

    public class Vehicle : BaseDeletableModel<string>
    {
        public Vehicle()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ShipmentsVehicles = new HashSet<ShipmentVehicle>();
        }

        /// <summary>
        /// Gets or sets model of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.VehicleModelNameMaxLenght)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the registration / plate number of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.VehiclePlateNumberMaxLenght)]
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee assigned with the vehicle.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Employee))]
        [Comment("The employee assigned with the vehicle.")]
        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets collection of shipments delivered with the vehicle.
        /// </summary>
        [Comment("Collection of shipments delivered with the vehicle.")]
        public virtual ICollection<ShipmentVehicle> ShipmentsVehicles { get; set; }
    }
}
