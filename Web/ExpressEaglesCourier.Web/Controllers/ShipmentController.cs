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

            try
            {
                await this.shipmentService.CreateShipmentAsync(model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, InvalidShipmentDetails);

                this.TempData[Message] = ex.Message;
                return this.View(model);
            }

            this.TempData[Message] = ShipmentCreated;

            return this.RedirectToAction(nameof(this.Add));
        }
    }
}
