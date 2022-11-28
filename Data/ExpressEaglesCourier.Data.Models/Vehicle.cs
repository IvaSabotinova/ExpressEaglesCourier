// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Vehicle : BaseDeletableModel<int>
    {
        public Vehicle()
        {
            this.ShipmentsVehicles = new HashSet<ShipmentVehicle>();
        }

        /// <summary>
        /// Gets or sets model of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(VehicleModelNameMaxLenght)]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the registration / plate number of the vehicle.
        /// </summary>
        [Required]
        [MaxLength(VehiclePlateNumberMaxLenght)]
        public string PlateNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee assigned with the vehicle.
        /// </summary>
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
