namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.StaffBoard
{
    public class StaffBoardViewModel
    {
        public int CustomersCount { get; set; }

        public int ShipmentsCount { get; set; }

        public int ShipmentTrackingPathsCount { get; set; }

        public ShipmentProductTypeViewModel ShipmentProductTypeViewModel { get; set; }
    }
}
