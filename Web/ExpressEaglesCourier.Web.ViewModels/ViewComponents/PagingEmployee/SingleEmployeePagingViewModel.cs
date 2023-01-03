namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingEmployee
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class SingleEmployeePagingViewModel : IMapFrom<Employee>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Position { get; set; }

        public string OfficeCityName { get; set; }

        public VehicleEmployeeViewModel Vehicle { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Employee, SingleEmployeePagingViewModel>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.Position, opt => opt.MapFrom(x => x.Position.JobTitle));
        }
    }
}
