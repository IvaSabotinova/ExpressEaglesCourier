namespace ExpressEaglesCourier.Web.ViewModels.Employees
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class EmployeeDetailsViewModel : IMapFrom<Employee>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null;

        public string PositionJobTitle { get; set; }

        public string ApplicationUserUserName { get; set; } = null;

        public string ApplicationUserEmail { get; set; } = null;

        public string OfficeDetails { get; set; } = null!;

        public string VehicleModel { get; set; } = null;

        public string VehiclePlateNumber { get; set; } = null;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Employee, EmployeeDetailsViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.MiddleName + " " + x.LastName))
                .ForMember(x => x.OfficeDetails, opt => opt.MapFrom(x => x.Office.Address + ", " + x.Office.City.Name + ", " + x.Office.City.Country.Name));
        }
    }
}
