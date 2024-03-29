﻿// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ExpressEaglesCourier.Data.Common.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Shipment : BaseDeletableModel<int>
    {
        public Shipment()
        {
            this.EmployeesShipments = new HashSet<EmployeeShipment>();
            this.Feedbacks = new HashSet<Feedback>();
            this.ShipmentsVehicles = new HashSet<ShipmentVehicle>();
            this.Images = new HashSet<ShipmentImage>();
        }

        [Required]
        [MaxLength(TrackingNumberMaxLength)]
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

        [Required]
        [MaxLength(AddressMaxLength)]
        public string PickupAddress { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string PickUpTown { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string PickUpCountry { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string DestinationAddress { get; set; }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string DestinationTown { get; set; }

        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string DestinationCountry { get; set; }

        [Required]
        public DeliveryType DeliveryType { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public DeliveryWay DeliveryWay { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [Column(TypeName = DecimalType)]
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

        public int? ShipmentTrackingPathId { get; set; }

        public virtual ShipmentTrackingPath ShipmentTrackingPath { get; set; }

        /// <summary>
        /// Gets or sets collection of vehicles used to deliver the shipment.
        /// </summary>
        [Comment("Collection of vehicles used to deliver the shipment.")]
        public virtual ICollection<ShipmentVehicle> ShipmentsVehicles { get; set; }

        /// <summary>
        /// Gets or sets collection of images related to the shipment.
        /// </summary>
        [Comment("Collection of images related to the shipment.")]
        public virtual ICollection<ShipmentImage> Images { get; set; }
    }
}
