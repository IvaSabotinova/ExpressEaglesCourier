namespace ExpressEaglesCourier.Data.Models
{
    using System;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentImage : BaseDeletableModel<string>
    {
        public ShipmentImage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the size of the image in bytes.
        /// </summary>
        [Comment("The size of the image in bytes.")]
        public int Size { get; set; }
    }
}
