namespace ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;

    public interface IShipmentTrackingPathService
    {
        Task<Shipment> GetShipmentById(int shipmentId);

        Task<int> CreateShipmentTrackingPathAsync(int shipmentId, ShipmentTrackingPathFormModel model);
    }
}
