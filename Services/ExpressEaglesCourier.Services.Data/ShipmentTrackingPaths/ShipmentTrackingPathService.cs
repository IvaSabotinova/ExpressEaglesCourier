namespace ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentTrackingPathService : IShipmentTrackingPathService
    {
        private readonly IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;

        public ShipmentTrackingPathService(
            IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo,
            IDeletableEntityRepository<Shipment> shipmentRepo)
        {
            this.shipmentTrackingPathRepo = shipmentTrackingPathRepo;
            this.shipmentRepo = shipmentRepo;
        }

        public async Task<Shipment> GetShipmentById(int shipmentId)
        {
            Shipment shipment = await this.shipmentRepo.All().FirstOrDefaultAsync(x => x.Id == shipmentId);

            if (shipment == null)
            {
                throw new ArgumentException(ShipmentNotExist);
            }

            return shipment;
        }

        public async Task<int> CreateShipmentTrackingPathAsync(int shipmentId, ShipmentTrackingPathFormModel model)
        {
            ShipmentTrackingPath shipmentTrackingPath = new ShipmentTrackingPath()
            {
                ShipmentId = shipmentId,
                TrackingNumber = model.TrackingNumber,
                PickedUpByCourier = model.PickedUpByCourier,
                SentFromDispatchingOffice = model.SentFromDispatchingOffice,
                ArrivalInReceivingOffice = model.ArrivalInReceivingOffice,
                FinalDeliveryPreparation = model.FinalDeliveryPreparation,
                FinalDelivery = model.FinalDelivery,
            };

            await this.shipmentTrackingPathRepo.AddAsync(shipmentTrackingPath);
            await this.shipmentTrackingPathRepo.SaveChangesAsync();

            Shipment shipment = await this.GetShipmentById(shipmentId);

            shipment.ShipmentTrackingPathId = shipmentTrackingPath.Id;

            await this.shipmentRepo.SaveChangesAsync();

            return shipmentTrackingPath.Id;
        }
    }
}
