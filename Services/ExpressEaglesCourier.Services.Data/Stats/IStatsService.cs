namespace ExpressEaglesCourier.Services.Data.Stats
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Administration.Dashboard;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponent;

    public interface IStatsService
    {
        Task<int> OfficesCountAsync();

        Task<int> EmployeesCountAsync();

        Task<int> VehiclesCountAsync();

        Task<int> CustomersCountAsync();

        Task<int> ShipmentsCountAsync();

        Task<int> ShipmentsTrackingPathsCountAsync();

        Task<DashboardViewModel> GetStatsAsync();

        Task<ShipmentProductTypeViewModel> GetProductTypeStats();
    }
}
