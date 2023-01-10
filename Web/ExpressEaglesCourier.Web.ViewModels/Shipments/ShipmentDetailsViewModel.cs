namespace ExpressEaglesCourier.Web.ViewModels.Shipments
{
    using System.Collections.Generic;

    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;

    public class ShipmentDetailsViewModel
    {
        public int Id { get; set; }

        public string TrackingNumber { get; set; }

        public string SenderFullName { get; set; }

        public string SenderPhoneNumber { get; set; }

        public string ReceiverFullName { get; set; }

        public string ReceiverPhoneNumber { get; set; }

        public string FullPickUpAddress { get; set; }

        public string FullDestinationAddress { get; set; }

        public string DeliveryType { get; set; }

        public string ProductType { get; set; }

        public string DeliveryWay { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<EmployeeShipmentViewModel> EmployeesShipments { get; set; } = new List<EmployeeShipmentViewModel>();

        public IEnumerable<SingleShipmentImageViewModel> Images { get; set; } = new List<SingleShipmentImageViewModel>();
    }
}
