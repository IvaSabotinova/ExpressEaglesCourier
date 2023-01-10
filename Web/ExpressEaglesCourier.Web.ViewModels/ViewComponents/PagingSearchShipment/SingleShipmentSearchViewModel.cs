namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment
{
    using System.Collections.Generic;

    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;

    public class SingleShipmentSearchViewModel : IMapFrom<Shipment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TrackingNumber { get; set; }

        public string SenderFirstName { get; set; }

        public string SenderLastName { get; set; }

        public string SenderPhoneNumber { get; set; }

        public string ReceiverFirstName { get; set; }

        public string ReceiverLastName { get; set; }

        public string ReceiverPhoneNumber { get; set; }

        public string PickUpAddress { get; set; }

        public string DestinationAddress { get; set; }

        public ProductType ProductType { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<SingleShipmentImageViewModel> Images { get; set; } = new List<SingleShipmentImageViewModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Shipment, SingleShipmentSearchViewModel>()
                .ForMember(x => x.PickUpAddress, opt =>
                opt.MapFrom(x => x.PickupAddress + ", " + x.PickUpTown + ", " + x.PickUpCountry))
                .ForMember(x => x.DestinationAddress, opt =>
                opt.MapFrom(x => x.DestinationAddress + ", " + x.DestinationTown + ", " + x.DestinationCountry));
        }
    }
}
