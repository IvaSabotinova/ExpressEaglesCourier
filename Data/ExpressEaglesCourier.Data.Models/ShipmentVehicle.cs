namespace ExpressEaglesCourier.Data.Models
{
    public class ShipmentVehicle
    {
        public int ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        public int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
