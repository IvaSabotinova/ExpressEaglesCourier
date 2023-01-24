namespace ExpressEaglesCourier.Services.Data.Searches
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;

    public interface ISearchService
    {
        Task<ShipmentTrackingPathDetailsModel> SearchTrackingPathAsync(string trackingNumber);

        Task<T> SearchShipmentByTrackingNumberAsync<T>(string trackingNumber);

        Task<T> SearchEmployeeByPhoneNumberAsync<T>(string phoneNumber);

        Task<T> SearchCustomerByPhoneNumberAsync<T>(string phoneNumber);

        Task<int> ShipmentsCountAsyncBySearchCriteria(string productType, string searchCustomerName, ShipmentSortingCriterion shipmentSortingCriterion);

        Task<IEnumerable<T>> GetAllShipmentsBySearchCriteria<T>(
            string productType,
            string searchCustomerName,
            ShipmentSortingCriterion shipmentSortingCriterion,
            int page,
            int itemsPerPage);
    }
}
