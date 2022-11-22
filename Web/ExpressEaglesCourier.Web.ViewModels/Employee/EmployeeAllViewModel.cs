namespace ExpressEaglesCourier.Web.ViewModels.Employee
{
    public class EmployeeAllViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Position { get; set; }

        public string OfficeCity { get; set; }

        public int ShipmentId { get; set; }

        // public ICollection<EmployeeShipment> EmployeeShipments { get; set; }
        public VehicleEmployeeViewModel Vehicle { get; set; }
    }
}
