namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult SearchTrackingPath()
        {
            return this.View();
        }

        public async Task<IActionResult> TrackingPathByTrackingNumber([FromQuery] string trackingNumber)
        {
            ShipmentTrackingPathDetailsModel model = await this.searchService.SearchTrackingPathAsync(trackingNumber);
            if (model != null)
            {
                return this.RedirectToAction("Details", "ShipmentTrackingPath", new { area="Staff", id = model.Id });
            }

            return this.View();
        }
    }
}
