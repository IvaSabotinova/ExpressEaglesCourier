namespace ExpressEaglesCourier.Web.ViewModels.Customers
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class CustomerDetailsViewModel : IMapFrom<Customer>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string FullAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }

        public int TotalNumberOfShipments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerDetailsViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.FullAddress, opt => opt.MapFrom(x => x.Address + ", " + x.City + ", " + x.Country))
                .ForMember(x => x.TotalNumberOfShipments, opt => opt.MapFrom(x => x.SentShipments.Count + x.ReceivedShipments.Count));
        }
    }
}
