namespace ExpressEaglesCourier.Web.Areas.Staff.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Data.ShipmentImages;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.Areas.Employee.Controllers;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentImageController : StaffController
    {
        private readonly IShipmentImageService shipmentImageService;
        private readonly IShipmentService shipmentService;
        private readonly IWebHostEnvironment environment;

        public ShipmentImageController(
            IShipmentImageService shipmentImageService,
            IShipmentService shipmentService,
            IWebHostEnvironment environment)
        {
            this.shipmentImageService = shipmentImageService;
            this.shipmentService = shipmentService;
            this.environment = environment;
        }

        public async Task<IActionResult> GetAllByShipmentId(int shipmentId, int page = 1)
        {
            if (shipmentId < 1)
            {
                return this.NotFound();
            }

            try
            {
                const int itemsPerPage = 2;
                ShipmentAllImagesViewModel model = new ShipmentAllImagesViewModel()
                {
                    ItemsPerPage = itemsPerPage,
                    CurrentPageNumber = page,
                    AllItemsCount = await this.shipmentImageService.ShipmentImagesCountAsync(shipmentId),
                    Images = await this.shipmentImageService.GetAllByShipmentId<SingleShipmentImageViewModel>(shipmentId, page, itemsPerPage),
                    ShipmentId = shipmentId,
                };
                return this.View(model);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, CannotFindImages);
                this.TempData[Message] = ex.Message;
                return this.RedirectToAction("Details", "Shipment", new { shipmentId });
            }
        }

        public async Task<IActionResult> Delete(string id, int shipmentId, int page = 1)
        {
            if (shipmentId < 1 || page < 1)
            {
                return this.NotFound();
            }

            Shipment shipment = await this.shipmentService.GetShipmentById(shipmentId);

            if (shipment != null)
            {
                int imageIndex = shipment.Images.ToList().FindIndex(x => x.Id == id);
                page = (imageIndex > 1 && imageIndex % 2 == 0) ? page - 1 : page;
            }

            string imagePath = $"{this.environment.WebRootPath}/images/shipments/";
            try
            {
                await this.shipmentImageService.DeleteShipmentImageAsync(id, imagePath);
                return this.RedirectToAction(nameof(this.GetAllByShipmentId), new { shipmentId, page });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ImageNotFound);
                this.TempData[Message] = ex.Message;
                return this.RedirectToAction(nameof(this.GetAllByShipmentId), new { shipmentId, page });
            }
        }
    }
}
