namespace ExpressEaglesCourier.Web.Areas.Staff.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Web.Areas.Employee.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
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
    }
}
