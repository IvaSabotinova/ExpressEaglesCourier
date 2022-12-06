namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    using System;

    public class ShipmentTrackingPathDetailsViewModel
    {
        public int Id { get; set; }

        public ShipmentView ShipmentDetails { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime? DateTimeAcceptanceFromCustomer { get; set; }

        public DateTime? DateTimePickedUpByCourier { get; set; }

        public string SendingOfficeAddress { get; set; }

        public string SendingOfficeCity { get; set; }

        public string SendingOfficeCountry { get; set; }

        public DateTime? DateTimeSentFromDispatchingOffice { get; set; }

        public string ReceivingOfficeAddress { get; set; }

        public string ReceivingOfficeCity { get; set; }

        public string ReceivingOfficeCountry { get; set; }

        public DateTime? DateTimeArrivalInReceivingOffice { get; set; }

        public DateTime? DateTimeFinalDeliveryPreparation { get; set; }

        public DateTime? DateTimeFinalDelivery { get; set; }
    }
}
