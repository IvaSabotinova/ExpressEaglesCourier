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
        [Comment("The shipment that tracking path is related to.")]
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the date and time of picking up shipment from customer.
        /// </summary>
        [Comment("Date and time of picking up shipment from customer.")]
        public DateTime? PickedUpByCourier { get; set; }

        /// <summary>
        /// Gets or sets the date and time of sending shipment from dispatching office.
        /// </summary>
        [Comment("Date and time of sending shipment from dispatching office.")]
        public DateTime? SentFromDispatchingOffice { get; set; }

        /// <summary>
        /// Gets or sets the date and time of shipment arrival in receiving office.
        /// </summary>
        [Comment("Date and time of shipment arrival in receiving office.")]
        public DateTime? ArrivalInReceivingOffice { get; set; }

        /// <summary>
        /// Gets or sets the date and time of shipment final processing / preparation for final delivery to customer.
        /// </summary>
        [Comment("Date and time of shipment final processing / preparation for final delivery to customer.")]
        public DateTime? FinalDeliveryPreparation { get; set; }

        /// <summary>
        /// Gets or sets the date and time of shipment's final delivery / handover to customer.
        /// </summary>
        [Comment("Date and time of shipment's final delivery / handover to customer.")]
        public DateTime? FinalDelivery { get; set; }
    }
}
