namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingEmployee
{
    using AutoMapper;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    public class VehicleEmployeeViewModel : IMapFrom<Vehicle>
    {
        public int Id { get; set; } = 0;

        public string Model { get; set; } = null;

        public string PlateNumber { get; set; } = null;
    }
}
