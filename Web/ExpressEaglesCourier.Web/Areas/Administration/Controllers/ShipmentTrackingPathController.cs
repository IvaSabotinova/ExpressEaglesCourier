namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Authorize]
    [Area("Administration")]
    public class ShipmentTrackingPathController : BaseController
    {
        private readonly IShipmentTrackingPathService shipmentTrackingPathService;

        public ShipmentTrackingPathController(IShipmentTrackingPathService shipmentTrackingPathService)
        {
            this.shipmentTrackingPathService = shipmentTrackingPathService;
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Create(int id)
        {
            ShipmentTrackingPathFormModel model = new ShipmentTrackingPathFormModel();
            model.ShipmentId = id;
            model.TrackingNumber = this.shipmentTrackingPathService.GetShipmentById(id).Result.TrackingNumber;
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create(int id, ShipmentTrackingPathFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                int shipmentTrackingPathId = await this.shipmentTrackingPathService.CreateShipmentTrackingPathAsync(id, model);

                this.TempData[Message] = ShipmentTrackingPathCreated;

                // return this.RedirectToAction(nameof(this.Details), new { id = shipmentTrackingPathId });
                return this.RedirectToAction("Index", "Home", new { area = string.Empty });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentTrackingPathDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }
        }
    }
}
