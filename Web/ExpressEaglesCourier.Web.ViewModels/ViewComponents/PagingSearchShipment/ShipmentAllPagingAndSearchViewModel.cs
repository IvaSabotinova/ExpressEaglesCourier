namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment
{
    using System.Collections.Generic;

    public class ShipmentAllPagingAndSearchViewModel : ShipmentPagingAndSearchViewModel
    {
        public IEnumerable<SingleShipmentSearchViewModel> Shipments { get; set; } = new List<SingleShipmentSearchViewModel>();
    }
}
