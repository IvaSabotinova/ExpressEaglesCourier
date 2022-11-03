namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentTrackingPath : BaseDeletableModel<string>
    {
        public ShipmentTrackingPath()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the shipment that tracking path is related to.
        /// </summary>
        [Required]
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the local time of registering the shipment in the system.
        /// </summary>
        [Comment("Local time of registering the shipment")]
        public DateTime? RegisteredOn { get; set; }

        /// <summary>
        /// Gets or sets the local time of picking up shipment from customer.
        /// </summary>
        [Comment("Local time of picking up shipment from customer.")]
        public DateTime? PickedUpByCourier { get; set; }

        /// <summary>
        /// Gets or sets the local time of sending shipment from dispatching office.
        /// </summary>
        [Comment("Local time of sending shipment from dispatching office.")]
        public DateTime? SentFromOffice { get; set; }

        /// <summary>
        /// Gets or sets the local time of shipment arrival in receiving office.
        /// </summary>
        [Comment("Local time of shipment arrival in receiving office.")]
        public DateTime? ArrivalAtOffice { get; set; }

        /// <summary>
        /// Gets or sets the local time of shipment final processing / preparation for final delivery to customer.
        /// </summary>
        [Comment("Local time of shipment final processing / preparation in office for final delivery to customer.")]
        public DateTime? FinalDeliveryPreparation { get; set; }

        /// <summary>
        /// Gets or sets the local time of shipment final delivery / handover to customer.
        /// </summary>
        [Comment("Local time of shipment final delivery / handover to customer.")]
        public DateTime? FinalDelivery { get; set; }
    }
}
