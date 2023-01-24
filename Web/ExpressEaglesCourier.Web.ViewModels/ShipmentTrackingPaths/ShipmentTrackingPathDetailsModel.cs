namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    using System;

    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class ShipmentTrackingPathDetailsModel : IMapFrom<ShipmentTrackingPath>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ShipmentView Shipment { get; set; }

        public string TrackingNumber { get; set; }

        public DateTime? AcceptanceFromCustomer { get; set; } = null;

        public DateTime? PickedUpByCourier { get; set; } = null;

        public string SendingOfficeAddress { get; set; }

        public string SendingOfficeCity { get; set; }

        public string SendingOfficeCountry { get; set; }

        public DateTime? SentFromDispatchingOffice { get; set; } = null;

        public string ReceivingOfficeAddress { get; set; }

        public string ReceivingOfficeCity { get; set; }

        public string ReceivingOfficeCountry { get; set; }

        public DateTime? ArrivalInReceivingOffice { get; set; } = null;

        public DateTime? FinalDeliveryPreparation { get; set; } = null;

        public DateTime? FinalDelivery { get; set; } = null;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ShipmentTrackingPath, ShipmentTrackingPathDetailsModel>()
                .ForMember(x => x.SendingOfficeAddress, opt => opt.Ignore())
                .ForMember(x => x.SendingOfficeCity, opt => opt.Ignore())
                .ForMember(x => x.SendingOfficeCountry, opt => opt.Ignore())
                .ForMember(x => x.ReceivingOfficeAddress, opt => opt.Ignore())
                .ForMember(x => x.ReceivingOfficeCity, opt => opt.Ignore())
                .ForMember(x => x.ReceivingOfficeCountry, opt => opt.Ignore());
        }
    }
}
