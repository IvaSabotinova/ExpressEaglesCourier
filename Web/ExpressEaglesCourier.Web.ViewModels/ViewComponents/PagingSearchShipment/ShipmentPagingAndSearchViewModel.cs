namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment
{
    public class ShipmentPagingAndSearchViewModel : PagingViewModel
    {
        public string ProductType { get; set; } = null;

        public string SearchCustomerName { get; set; } = null;

        public ShipmentSortingCriterion ShipmentSortingCriterion { get; set; } = 0;
    }
}
