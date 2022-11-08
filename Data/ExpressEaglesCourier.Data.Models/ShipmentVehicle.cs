namespace ExpressEaglesCourier.Data.Models
{
    public class ShipmentVehicle
    {
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public string VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
