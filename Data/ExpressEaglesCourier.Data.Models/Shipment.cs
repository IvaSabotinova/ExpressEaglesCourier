// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class Shipment : BaseDeletableModel<string>
    {
        public Shipment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmployeesShipments = new HashSet<EmployeeShipment>();
            this.Feedbacks = new HashSet<Feedback>();
            this.ShipmentsVehicles = new HashSet<ShipmentVehicle>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.TrackingNumberMaxLength)]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the customer that sends the shipment.
        /// </summary>
        [Required]
        public string SenderId { get; set; }

        public virtual Customer Sender { get; set; }

        /// <summary>
        /// Gets or sets the receiver of the shipment.
        /// </summary>
        [Required]
        public string ReceiverId { get; set; }

        public virtual Customer Receiver { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.AddressMaxLength)]
        public string PickupAddress { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.CityNameMaxLength)]
        public string PickUpTown { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.AddressMaxLength)]
        public string DestinationAddress { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.CityNameMaxLength)]
        public string DestinationTown { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public ProductType ProductType { get; set; }

        public double Weight { get; set; }

        [Column(TypeName = GlobalConstants.EntitiesConstants.DecimalType)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets collection of employees who handled the shipment.
        /// </summary>
        [Comment("Collection of employees who handled the shipment.")]
        public virtual ICollection<EmployeeShipment> EmployeesShipments { get; set; }

        /// <summary>
        /// Gets or sets collection of feedbacks received from the shipment's sender or receiver.
        /// </summary>
        [Comment("Feedback received from the shipment's sender or receiver.")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public string ShipmentTrackingPathId { get; set; }

        public virtual ShipmentTrackingPath ShipmentTrackingPath { get; set; }

        /// <summary>
        /// Gets or sets collection of vehicles used to deliver the shipment.
        /// </summary>
        [Comment("Collection of vehicles used to deliver the shipment.")]
        public virtual ICollection<ShipmentVehicle> ShipmentsVehicles { get; set; }
    }
}
