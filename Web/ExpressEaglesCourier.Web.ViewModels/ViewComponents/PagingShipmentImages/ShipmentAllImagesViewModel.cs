namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingShipmentImages
{
    using System.Collections.Generic;

    public class ShipmentAllImagesViewModel : ShipmentImagesPagingViewModel
    {
        public IEnumerable<SingleShipmentImageViewModel> Images { get; set; } = new List<SingleShipmentImageViewModel>();
    }
}
