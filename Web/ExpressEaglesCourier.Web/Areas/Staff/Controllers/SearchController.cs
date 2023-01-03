namespace ExpressEaglesCourier.Web.Areas.Staff.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Web.Areas.Employee.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : StaffController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult SearchShipment()
        {
            return this.View();
        }

        public async Task<IActionResult> ShipmentByTrackingNumber([FromQuery] string trackingNumber)
        {
            ShipmentDetailsViewModel model = await this.searchService.SearchShipmentByTrackingNumberAsync(trackingNumber);
            if (model != null)
            {
                return this.RedirectToAction("Details", "Shipment", new { id = model.Id });
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult SearchCustomer()
        {
            return this.View();
        }

        public async Task<IActionResult> CustomerByPhoneNumber([FromQuery] string phoneNumber)
        {
            CustomerDetailsViewModel model = await this.searchService.SearchCustomerByPhoneNumberAsync(phoneNumber);

            if (model != null)
            {
                return this.RedirectToAction("Details", "Customer", new { id = model.Id });
            }

            return this.View();
        }

        public async Task<IActionResult> GetAndSearchAllShipments(string productType, string searchCustomerName, ShipmentSortingCriterion shipmentSortingCriterion = 0, int page = 1)
        {
            if (page < 1)
            {
                return this.NotFound();
            }

            const int itemsPerPage = 2;
            ShipmentAllPagingAndSearchViewModel model = new ShipmentAllPagingAndSearchViewModel()
            {
                ItemsPerPage = itemsPerPage,
                CurrentPageNumber = page,
                AllItemsCount = await this.searchService.ShipmentsCountAsyncBySearchCriteria(productType, searchCustomerName, shipmentSortingCriterion),
                Shipments = await this.searchService.GetAllShipmentsBySearchCriteria<SingleShipmentSearchViewModel>(productType, searchCustomerName, shipmentSortingCriterion, page, itemsPerPage),
                ProductType = productType,
                SearchCustomerName = searchCustomerName,
                ShipmentSortingCriterion = shipmentSortingCriterion,
            };

            return this.View(model);
        }
    }
}
