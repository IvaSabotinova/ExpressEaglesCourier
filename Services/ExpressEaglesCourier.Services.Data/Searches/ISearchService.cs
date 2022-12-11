namespace ExpressEaglesCourier.Services.Data.Searches
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;

    public interface ISearchService
    {
        Task<ShipmentTrackingPathDetailsModel> SearchTrackingPathAsync(string trackingNumber);

        Task<ShipmentDetailsViewModel> SearchShipmentByTrackingNumberAsync(string trackingNumber);

        Task<EmployeeDetailsViewModel> SearchEmployeeByPhoneNumberAsync(string phoneNumber);

        Task<CustomerDetailsViewModel> SearchCustomerByPhoneNumberAsync(string phoneNumber);
    }
}
