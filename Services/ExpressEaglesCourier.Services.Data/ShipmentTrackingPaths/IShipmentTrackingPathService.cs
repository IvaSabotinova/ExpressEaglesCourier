﻿namespace ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;

    public interface IShipmentTrackingPathService
    {
        Task<Shipment> GetShipmentById(int shipmentId);

        Task<int> CreateShipmentTrackingPathAsync(ShipmentTrackingPathFormModel model);

        Task<ShipmentTrackingPath> GetTrackingPathById(int shipmentTrackingPathId);

        Task<ShipmentTrackingPathDetailsModel> GetDetailsByTrackingPathId(int shipmentTrackPathId);

        Task<TModel> GetDetailsById<TModel>(int shipmentTrackingPathId);

        Task UpdateShipmentTrackingPathAsync(ShipmentTrackingPathFormModel model);
    }
}
