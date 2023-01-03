namespace ExpressEaglesCourier.Services.Data.Searches
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;

    public interface ISearchService
    {
        Task<ShipmentTrackingPathDetailsModel> SearchTrackingPathAsync(string trackingNumber);

        Task<ShipmentDetailsViewModel> SearchShipmentByTrackingNumberAsync(string trackingNumber);

        Task<EmployeeDetailsViewModel> SearchEmployeeByPhoneNumberAsync(string phoneNumber);

        Task<CustomerDetailsViewModel> SearchCustomerByPhoneNumberAsync(string phoneNumber);

        Task<int> ShipmentsCountAsyncBySearchCriteria(string productType, string searchCustomerName, ShipmentSortingCriterion shipmentSortingCriterion);

        Task<IEnumerable<T>> GetAllShipmentsBySearchCriteria<T>(
            string productType,
            string searchCustomerName,
            ShipmentSortingCriterion shipmentSortingCriterion,
            int page,
            int itemsPerPage);
    }
}
