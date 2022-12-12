namespace ExpressEaglesCourier.Web.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ShipmentTrackingPathController : BaseController
    {
        private readonly IShipmentTrackingPathService shipmentTrackingPathService;

        public ShipmentTrackingPathController(IShipmentTrackingPathService shipmentTrackingPathService)
        {
            this.shipmentTrackingPathService = shipmentTrackingPathService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ShipmentTrackingPath shipmentTrackingPath = await this.shipmentTrackingPathService.GetTrackingPathById(id);
            if (shipmentTrackingPath == null)
            {
                return this.NotFound();
            }

            ShipmentTrackingPathDetailsModel model = await this.shipmentTrackingPathService.Details(id);
            return this.View(model);
        }
    }
}
