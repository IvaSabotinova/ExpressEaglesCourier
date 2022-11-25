namespace ExpressEaglesCourier.Data.Models
{
    using System;

    using ExpressEaglesCourier.Data.Common.Models;

    public class ShipmentVehicle : IDeletableEntity
    {
        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
