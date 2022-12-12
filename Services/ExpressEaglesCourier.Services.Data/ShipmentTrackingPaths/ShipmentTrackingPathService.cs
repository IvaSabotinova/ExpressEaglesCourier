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
                throw new ArgumentException(ShipmentNotExist);
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
                throw new ArgumentException(TrackingNumberIncorrect);
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

        public async Task<ShipmentTrackingPathDetailsModel> Details(int shipmentTrackPathId)
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

            Shipment shipment = await this.shipmentRepo.AllAsNoTracking()
                .Include(x => x.Sender)
                .Include(x => x.Receiver)
                .FirstOrDefaultAsync(x => x.Id == shipmentTrackingPath.ShipmentId);

            ShipmentTrackingPathDetailsModel model = new ShipmentTrackingPathDetailsModel()
            {
                Id = shipmentTrackPathId,
                TrackingNumber = shipmentTrackingPath.TrackingNumber,
                DateTimeAcceptanceFromCustomer = shipmentTrackingPath.AcceptanceFromCustomer ?? null,
                DateTimePickedUpByCourier = shipmentTrackingPath.PickedUpByCourier ?? null,
                SendingOfficeAddress = sendingOffice?.Address ?? null,
                SendingOfficeCity = sendingOffice?.City.Name ?? null,
                SendingOfficeCountry = sendingOffice?.City.Country.Name ?? null,
                DateTimeSentFromDispatchingOffice = shipmentTrackingPath.SentFromDispatchingOffice ?? null,
                ReceivingOfficeAddress = receivingOffice?.Address ?? null,
                ReceivingOfficeCity = receivingOffice?.City.Name ?? null,
                ReceivingOfficeCountry = receivingOffice?.City.Country.Name ?? null,
                DateTimeArrivalInReceivingOffice = shipmentTrackingPath.ArrivalInReceivingOffice ?? null,
                DateTimeFinalDeliveryPreparation = shipmentTrackingPath.FinalDeliveryPreparation ?? null,
                DateTimeFinalDelivery = shipmentTrackingPath.FinalDelivery ?? null,
                ShipmentDetails = new ShipmentView()
                {
                    ShipmentId = shipmentTrackingPath.ShipmentId,
                    SenderName = $"{shipment.Sender.FirstName} {shipment.Sender.LastName}",
                    PickUpAddressCityCountry = $"{shipment.PickupAddress}, {shipment.PickUpTown}, {shipment.PickUpCountry}",
                    ReceiverName = $"{shipment.Receiver.FirstName} {shipment.Receiver.LastName}",
                    DestinationAddressCityCountry = $"{shipment.DestinationAddress}, {shipment.DestinationTown}, {shipment.DestinationCountry}",
                },
            };

            return model;
        }

        public async Task<ShipmentTrackingPathFormModel> GetTrackingPathForUpdate(int shipmentTrackingPathId)
        {
            ShipmentTrackingPath shipmentTrackingPath = await this.GetTrackingPathById(shipmentTrackingPathId);

            if (shipmentTrackingPath == null)
            {
                throw new ArgumentException(TrackingPathNotFound);
            }

            ShipmentTrackingPathFormModel model = new ShipmentTrackingPathFormModel()
            {
                Id = shipmentTrackingPath.Id,
                TrackingNumber = shipmentTrackingPath.TrackingNumber,
                ShipmentId = shipmentTrackingPath.ShipmentId,
                AcceptanceFromCustomer = shipmentTrackingPath.AcceptanceFromCustomer,
                PickedUpByCourier = shipmentTrackingPath.PickedUpByCourier,
                SendingOfficeId = shipmentTrackingPath.SendingOfficeId,
                SentFromDispatchingOffice = shipmentTrackingPath.SentFromDispatchingOffice,
                ReceivingOfficeId = shipmentTrackingPath.ReceivingOfficeId,
                ArrivalInReceivingOffice = shipmentTrackingPath.ArrivalInReceivingOffice,
                FinalDeliveryPreparation = shipmentTrackingPath.FinalDeliveryPreparation,
                FinalDelivery = shipmentTrackingPath.FinalDelivery,
            };

            return model;
        }

        public async Task UpdateShipmentTrackingPathAsync(ShipmentTrackingPathFormModel model)
        {
            ShipmentTrackingPath shipmentTrackingPath = await this.GetTrackingPathById(model.Id);

            if (shipmentTrackingPath == null)
            {
                throw new ArgumentException(TrackingPathNotFound);
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
                throw new ArgumentException(TrackingNumberIncorrect);
            }

            await this.shipmentTrackingPathRepo.SaveChangesAsync();
        }

        // public async Task DeleteTrackingPathAsync(int shipmentTrackingPathId)
        // {
        //    ShipmentTrackingPath shipmentTrackingPath = await this.GetTrackingPathById(shipmentTrackingPathId);
        //    this.shipmentTrackingPathRepo.Delete(shipmentTrackingPath);
        //    await this.shipmentTrackingPathRepo.SaveChangesAsync();
        // }
    }
}
