namespace ExpressEaglesCourier.Web.ViewComponents
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.ShipmentImages;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages;
    using Microsoft.AspNetCore.Mvc;

    public class PagingShipmentImageViewComponent : ViewComponent
    {
        private readonly IShipmentImageService shipmentImageService;

        public PagingShipmentImageViewComponent(IShipmentImageService shipmentImageService)
        {
            this.shipmentImageService = shipmentImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int shipmentId, int page = 1)
        {
            ShipmentImagesPagingViewModel model = new ShipmentImagesPagingViewModel()
            {
                ItemsPerPage = 2,
                CurrentPageNumber = page,
                AllItemsCount = await this.shipmentImageService.ShipmentImagesCountAsync(shipmentId),
                ShipmentId = shipmentId,
            };

            return this.View(model);
        }
    }
}
