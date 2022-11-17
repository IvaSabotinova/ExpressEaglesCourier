namespace ExpressEaglesCourier.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    [Authorize]
    public class ShipmentController : BaseController
    {
        private readonly IShipmentService shipmentService;

        public ShipmentController(IShipmentService shipmentService)
        {
            this.shipmentService = shipmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Add()
        {
            AddNewShipmentModel model = new AddNewShipmentModel();
            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(AddNewShipmentModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            int id;

            try
            {
                id = await this.shipmentService.CreateShipmentAsync(model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }

            this.TempData[Message] = ShipmentCreated;

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.shipmentService.ShipmentExists(id))
            {
                return this.BadRequest();
            }

            ShipmentDetailsViewModel model = await this.shipmentService.GetShipmentDetails(id);

            return this.View(model);
        }
    }
}
