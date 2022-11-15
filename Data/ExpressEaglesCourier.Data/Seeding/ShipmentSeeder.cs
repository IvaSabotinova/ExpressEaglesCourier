namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Customer customer1 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359877111111");
            Customer customer2 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359877334334");
            Customer customer3 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359877222222");
            Customer customer4 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359898554554");
            Customer customer5 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359899555555");
            Customer customer6 = await dbContext.Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359888556556");
            List<Shipment> shipments = new List<Shipment>()
            {
            new Shipment()
            {
                TrackingNumber = "11111011010",
                SenderId = customer1.Id,
                PickupAddress = customer1.Address,
                PickUpTown = customer1.City,
                PickUpCountry = customer1.Country,
                ReceiverId = customer4.Id,
                DestinationAddress = customer4.Address,
                DestinationTown = customer4.City,
                DestinationCountry = customer4.Country,
                DeliveryType = DeliveryType.SamedayCourier,
                ProductType = ProductType.Textile,
                Weight = 1.2,
                Price = 5.20M,
            },
            new Shipment()
            {
                TrackingNumber = "11111011012",
                SenderId = customer2.Id,
                PickupAddress = customer2.Address,
                PickUpTown = customer2.City,
                PickUpCountry = customer2.Country,
                ReceiverId = customer5.Id,
                DestinationAddress = customer5.Address,
                DestinationTown = customer5.City,
                DestinationCountry = customer5.Country,
                DeliveryType = DeliveryType.OvernightShipping,
                ProductType = ProductType.Documents,
                Weight = 0.5,
                Price = 5.10M,
            },
            new Shipment()
            {
                TrackingNumber = "11111011013",
                SenderId = customer3.Id,
                PickupAddress = customer3.Address,
                PickUpTown = customer3.City,
                PickUpCountry = customer3.Country,
                ReceiverId = customer6.Id,
                DestinationAddress = customer6.Address,
                DestinationTown = customer6.City,
                DestinationCountry = customer6.Country,
                DeliveryType = DeliveryType.StandardDeliveryService,
                ProductType = ProductType.Textile,
                Weight = 3.50,
                Price = 4.25M,
            },
            new Shipment()
            {
                TrackingNumber = "11111011011",
                SenderId = customer6.Id,
                PickupAddress = customer6.Address,
                PickUpTown = customer6.City,
                PickUpCountry = customer6.Country,
                ReceiverId = customer1.Id,
                DestinationAddress = customer1.Address,
                DestinationTown = customer1.City,
                DestinationCountry = customer1.Country,
                DeliveryType = DeliveryType.SamedayCourier,
                ProductType = ProductType.Medicaments,
                Weight = 0.80,
                Price = 5.90M,
            },
            new Shipment()
            {
                TrackingNumber = "11111011015",
                SenderId = customer4.Id,
                PickupAddress = customer4.Address,
                PickUpTown = customer4.City,
                PickUpCountry = customer4.Country,
                ReceiverId = customer2.Id,
                DestinationAddress = customer2.Address,
                DestinationTown = customer2.City,
                DestinationCountry = customer2.Country,
                DeliveryType = DeliveryType.OvernightShipping,
                ProductType = ProductType.Documents,
                Weight = 0.75,
                Price = 5.10M,
            },
            new Shipment()
            {
                TrackingNumber = "11111011016",
                SenderId = customer5.Id,
                PickupAddress = customer5.Address,
                PickUpTown = customer5.City,
                PickUpCountry = customer5.Country,
                ReceiverId = customer2.Id,
                DestinationAddress = customer2.Address,
                DestinationTown = customer2.City,
                DestinationCountry = customer2.Country,
                DeliveryType = DeliveryType.StandardDeliveryService,
                ProductType = ProductType.Technique,
                Weight = 2.80,
                Price = 5.90M,
            },
            };

            await dbContext.Shipments.AddRangeAsync(shipments);
        }
    }
}
