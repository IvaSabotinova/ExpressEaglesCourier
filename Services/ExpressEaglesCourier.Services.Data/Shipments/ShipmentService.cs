﻿namespace ExpressEaglesCourier.Services.Data.Shipments
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class ShipmentService : IShipmentService
    {
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IDeletableEntityRepository<Customer> customerRepo;

        public ShipmentService(
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IDeletableEntityRepository<Customer> customerRepo)
        {
            this.shipmentRepo = shipmentRepo;
            this.customerRepo = customerRepo;
        }

        public async Task CreateShipmentAsync(AddNewShipmentModel model)
        {
            if (await this.TrackingNumberExists(model.TrackingNumber))
            {
                throw new ArgumentException(TrackingNumberExistsInDB);
            }

            if (await this.CustomerWithPhoneNumberExists(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber) == false)
            {
                throw new ArgumentException(SenderWithPhoneNumberDoesNotExit);
            }

            if (await this.CustomerWithPhoneNumberExists(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber) == false)
            {
                throw new ArgumentException(ReceiverWithPhoneNumberDoesNotExit);
            }

            string senderId = await this.GetCustomerId(model.SenderFirstName, model.SenderLastName, model.SenderPhoneNumber);

            string receiverId = await this.GetCustomerId(model.ReceiverFirstName, model.ReceiverLastName, model.ReceiverPhoneNumber);

            Shipment newShipment = new Shipment()
            {
                TrackingNumber = model.TrackingNumber,
                SenderId = senderId,
                ReceiverId = receiverId,
                PickupAddress = model.PickUpAddress,
                PickUpTown = model.PickUpTown,
                PickUpCountry = model.PickUpCountry,
                DestinationAddress = model.DestinationAddress,
                DestinationTown = model.DestinationTown,
                DestinationCountry = model.DestinationCountry,
                DeliveryType = model.DeliveryType,
                ProductType = model.ProductType,
                Weight = model.Weight,
                Price = model.Price,
            };

            await this.shipmentRepo.AddAsync(newShipment);
            await this.shipmentRepo.SaveChangesAsync();
        }

        public async Task<bool> TrackingNumberExists(string trackingNumber)
        {
            return await this.shipmentRepo.AllAsNoTracking().Select(x => x.TrackingNumber).ContainsAsync(trackingNumber);
        }

        public async Task<bool> CustomerWithPhoneNumberExists(string firstName, string lastName, string phoneNumber)
        {
            return await this.customerRepo.AllAsNoTracking().AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber);
        }

        public async Task<string> GetCustomerId(string firstName, string lastName, string phoneNumber)
        {
            Customer customer = await this.customerRepo.AllAsNoTracking().FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber);

            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            return customer.Id;
        }
    }
}