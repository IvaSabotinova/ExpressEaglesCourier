namespace ExpressEaglesCourier.Data.Models
{
    public class EmployeeShipment
    {
        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public string EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
