namespace ExpressEaglesCourier.Web.ViewModels.Shipments
{
    using System.Collections.Generic;

    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;

    public class ShipmentDetailsViewModel : SingleShipmentSearchViewModel, IMapFrom<Shipment>, IHaveCustomMappings
    {
        public DeliveryType DeliveryType { get; set; }

        public DeliveryWay DeliveryWay { get; set; }

        public double Weight { get; set; }

        public IEnumerable<EmployeeShipmentViewModel> EmployeesShipments { get; set; } = new List<EmployeeShipmentViewModel>();

        public new void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Shipment, ShipmentDetailsViewModel>()
                .ForMember(x => x.PickUpAddress, opt =>
                opt.MapFrom(x => x.PickupAddress + ", " + x.PickUpTown + ", " + x.PickUpCountry))
                .ForMember(x => x.DestinationAddress, opt =>
                opt.MapFrom(x => x.DestinationAddress + ", " + x.DestinationTown + ", " + x.DestinationCountry));
        }
    }
}
