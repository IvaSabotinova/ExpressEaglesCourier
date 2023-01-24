namespace ExpressEaglesCourier.Web.ViewModels.Shipments
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class EmployeeShipmentViewModel : IMapFrom<EmployeeShipment>, IHaveCustomMappings
    {
        public string EmployeeId { get; set; }

        public string FullName { get; set; }

        public string EmployeePositionJobTitle { get; set; }

        public string EmployeeOfficeCityName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<EmployeeShipment, EmployeeShipmentViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.Employee.FirstName + " " + x.Employee.LastName));
        }
    }
}
