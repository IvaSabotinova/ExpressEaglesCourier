namespace ExpressEaglesCourier.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShipmentVehicle
    {
        public string ShipmentId { get; set; }

        public Shipment Shipment { get; set; }

        public string VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
