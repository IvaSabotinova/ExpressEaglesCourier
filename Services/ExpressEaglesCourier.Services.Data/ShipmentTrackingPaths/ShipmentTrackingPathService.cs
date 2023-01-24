namespace ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentTrackingPathService : IShipmentTrackingPathService
    {
        private readonly IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IDeletableEntityRepository<Office> officeRepo;

        public ShipmentTrackingPathService(
            IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo,
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IDeletableEntityRepository<Office> officeRepo)
        {
            this.shipmentTrackingPathRepo = shipmentTrackingPathRepo;
            this.shipmentRepo = shipmentRepo;
            this.officeRepo = officeRepo;
        }

        public async Task<Shipment> GetShipmentById(int shipmentId)
        {
            Shipment shipment = await this.shipmentRepo.All().FirstOrDefaultAsync(x => x.Id == shipmentId);

            if (shipment == null)
            {
                throw new NullReferenceException(ShipmentNotExist);
            }

            return shipment;
        }

        public async Task<int> CreateShipmentTrackingPathAsync(ShipmentTrackingPathFormModel model)
        {
            ShipmentTrackingPath shipmentTrackingPath = new ShipmentTrackingPath()
            {
                ShipmentId = model.ShipmentId,
                TrackingNumber = model.TrackingNumber,
                AcceptanceFromCustomer = model.AcceptanceFromCustomer,
                PickedUpByCourier = model.PickedUpByCourier,
                SendingOfficeId = model.SendingOfficeId,
                SentFromDispatchingOffice = model.SentFromDispatchingOffice,
                ReceivingOfficeId = model.ReceivingOfficeId,
                ArrivalInReceivingOffice = model.ArrivalInReceivingOffice,
                FinalDeliveryPreparation = model.FinalDeliveryPreparation,
                FinalDelivery = model.FinalDelivery,
            };

            Shipment shipment = await this.GetShipmentById(model.ShipmentId);

            if (shipment.TrackingNumber != model.TrackingNumber)
            {
                throw new InvalidOperationException(TrackingNumberIncorrect);
            }

            if (shipment.ShipmentTrackingPathId != null)
            {
                throw new ArgumentException(ShipmentTrackingPathExist);
            }

            await this.shipmentTrackingPathRepo.AddAsync(shipmentTrackingPath);
            await this.shipmentTrackingPathRepo.SaveChangesAsync();

            shipment.ShipmentTrackingPathId = shipmentTrackingPath.Id;

            await this.shipmentRepo.SaveChangesAsync();

            return shipmentTrackingPath.Id;
        }

        public async Task<ShipmentTrackingPath> GetTrackingPathById(int shipmentTrackingPathId)
            => await this.shipmentTrackingPathRepo.All().FirstOrDefaultAsync(x => x.Id == shipmentTrackingPathId);

        public async Task<ShipmentTrackingPathDetailsModel> GetDetailsByTrackingPathId(int shipmentTrackPathId)
        {
            ShipmentTrackingPath shipmentTrackingPath = await this.GetTrackingPathById(shipmentTrackPathId);

            Office sendingOffice = await this.officeRepo.AllAsNoTracking()
                .Include(x => x.City)
                .ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == shipmentTrackingPath.SendingOfficeId);

            Office receivingOffice = await this.officeRepo.AllAsNoTracking()
                .Include(x => x.City)
                .ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == shipmentTrackingPath.ReceivingOfficeId);

            ShipmentTrackingPathDetailsModel model = await this.shipmentTrackingPathRepo.AllAsNoTracking()
                .Where(x => x.Id == shipmentTrackPathId)
                .To<ShipmentTrackingPathDetailsModel>()
                .FirstOrDefaultAsync();

            model.SendingOfficeAddress = sendingOffice?.Address ?? null;
            model.SendingOfficeCity = sendingOffice?.City.Name ?? null;
            model.SendingOfficeCountry = sendingOffice?.City.Country.Name ?? null;
            model.ReceivingOfficeAddress = receivingOffice?.Address ?? null;
            model.ReceivingOfficeCity = receivingOffice?.City.Name ?? null;
            model.ReceivingOfficeCountry = receivingOffice?.City.Country.Name ?? null;

            return model;
        }

        public async Task<TModel> GetDetailsById<TModel>(int shipmentTrackingPathId)
        => await this.shipmentTrackingPathRepo.AllAsNoTracking()
                .Where(x => x.Id == shipmentTrackingPathId)
                .To<TModel>()
                .FirstOrDefaultAsync();

        public async Task UpdateShipmentTrackingPathAsync(ShipmentTrackingPathFormModel model)
        {
            ShipmentTrackingPath shipmentTrackingPath = await this.GetTrackingPathById(model.Id);

            if (shipmentTrackingPath == null)
            {
                throw new NullReferenceException(TrackingPathNotFound);
            }

            shipmentTrackingPath.TrackingNumber = model.TrackingNumber;
            shipmentTrackingPath.ShipmentId = model.ShipmentId;
            shipmentTrackingPath.AcceptanceFromCustomer = model.AcceptanceFromCustomer ?? null;
            shipmentTrackingPath.PickedUpByCourier = model.PickedUpByCourier ?? null;
            shipmentTrackingPath.SendingOfficeId = model.SendingOfficeId;
            shipmentTrackingPath.SentFromDispatchingOffice = model.SentFromDispatchingOffice ?? null;
            shipmentTrackingPath.ReceivingOfficeId = model.ReceivingOfficeId;
            shipmentTrackingPath.ArrivalInReceivingOffice = model.ArrivalInReceivingOffice ?? null;
            shipmentTrackingPath.FinalDeliveryPreparation = model.FinalDeliveryPreparation ?? null;
            shipmentTrackingPath.FinalDelivery = model.FinalDelivery ?? null;

            Shipment shipment = await this.GetShipmentById(model.ShipmentId);

            if (shipment.TrackingNumber != model.TrackingNumber)
            {
                throw new InvalidOperationException(TrackingNumberIncorrect);
            }

            await this.shipmentTrackingPathRepo.SaveChangesAsync();
        }
    }
}
