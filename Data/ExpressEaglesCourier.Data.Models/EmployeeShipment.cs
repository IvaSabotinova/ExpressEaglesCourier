namespace ExpressEaglesCourier.Data.Models
{
    using System;

    using ExpressEaglesCourier.Data.Common.Models;

    public class EmployeeShipment : IDeletableEntity
    {
        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
