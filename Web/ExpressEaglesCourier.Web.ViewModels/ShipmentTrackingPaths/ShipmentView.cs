namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    public class ShipmentView
    {
        public int ShipmentId { get; set; }

        public string SenderName { get; set; }

        public string PickUpAddressCityCountry { get; set; }

        public string ReceiverName { get; set; }

        public string DestinationAddressCityCountry { get; set; }
    }
}
