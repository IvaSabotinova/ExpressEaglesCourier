namespace ExpressEaglesCourier.Web.ViewModels.Shipments
{
    using System.Collections.Generic;

    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;

    public class ShipmentDetailsViewModel : IMapFrom<Shipment>, IHaveCustomMappings
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Shipment, ShipmentDetailsViewModel>()
                .ForMember(x => x.SenderFullName, opt => opt.MapFrom(x => x.Sender.FirstName + " " + x.Sender.LastName))
                .ForMember(x => x.ReceiverFullName, opt => opt.MapFrom(x => x.Receiver.FirstName + " " + x.Receiver.LastName))
                .ForMember(x => x.FullPickUpAddress, opt => opt.MapFrom(x => x.PickupAddress + ", " + x.PickUpTown + ", " + x.PickUpCountry))
                .ForMember(x => x.FullDestinationAddress, opt => opt.MapFrom(x => x.DestinationAddress + ", " + x.DestinationTown + ", " + x.DestinationCountry))
                .ForMember(x => x.DeliveryWay, opt => opt.MapFrom(x => x.DeliveryWay.ToString()))
                .ForMember(x => x.DeliveryType, opt => opt.MapFrom(x => x.DeliveryType.ToString()))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(x => x.ProductType.ToString()));
        }
    }
}
