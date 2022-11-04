namespace ExpressEaglesCourier.Data.Models
{
    public class ShipmentEmployee
    {
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string ShipmentId { get; set; }

        public Shipment Shipment { get; set; }
    }
}
