namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class ShipmentView : IMapFrom<Shipment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        public string PickUpAddressCityCountry { get; set; }

        public string ReceiverName { get; set; }

        public string DestinationAddressCityCountry { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Shipment, ShipmentView>()
                .ForMember(x => x.SenderName, opt => opt.MapFrom(x => x.Sender.FirstName + " " + x.Sender.LastName))
                .ForMember(x => x.PickUpAddressCityCountry, opt => opt.MapFrom(x => x.PickupAddress + ", " + x.PickUpTown + ", " + x.PickUpCountry))
                .ForMember(x => x.ReceiverName, opt => opt.MapFrom(x => x.Receiver.FirstName + " " + x.Receiver.LastName))
                .ForMember(x => x.DestinationAddressCityCountry, opt => opt.MapFrom(x => x.DestinationAddress + ", " + x.DestinationTown + ", " + x.DestinationCountry));
        }
    }
}
