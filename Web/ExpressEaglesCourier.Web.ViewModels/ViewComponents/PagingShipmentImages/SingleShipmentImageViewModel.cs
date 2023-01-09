namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class SingleShipmentImageViewModel : IMapFrom<ShipmentImage>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ShipmentTrackingNumber { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ShipmentImage, SingleShipmentImageViewModel>()
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => "/images/shipments/" + x.Id + "." + x.Extension));
        }
    }
}
