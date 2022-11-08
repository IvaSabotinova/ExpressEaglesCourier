namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;

    public class ShipmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Customer customer1 = dbContext.Customers.Find("433b2d5c-4886-4069-a54d-3adec39187f0");
            Customer customer2 = dbContext.Customers.Find("6cb47b02-d240-4a69-a8b6-1bd5c74c69c7");
            Customer customer3 = dbContext.Customers.Find("bbe661fb-331c-4e43-ba3f-bc9c4b194c89");
            Customer customer4 = dbContext.Customers.Find("891d9904-b5f6-4756-aeed-4ec702d97599");
            Customer customer5 = dbContext.Customers.Find("a21b27c3-c52b-40c8-9145-085e9f430801");
            Customer customer6 = dbContext.Customers.Find("d3945efc-878f-4224-983b-48769370cf7c");
            List<Shipment> shipments = new List<Shipment>()
            {
            new Shipment()
            {
                TrackingNumber = "11111011010",
                SenderId = customer1.Id,
                PickupAddress = customer1.Address,
                PickUpTown = customer1.City,
                ReceiverId = customer4.Id,
                DestinationAddress = customer4.Address,
                DestinationTown = customer4.City,
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
                ReceiverId = customer5.Id,
                DestinationAddress = customer5.Address,
                DestinationTown = customer5.City,
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
                ReceiverId = customer6.Id,
                DestinationAddress = customer6.Address,
                DestinationTown = customer6.City,
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
                ReceiverId = customer1.Id,
                DestinationAddress = customer1.Address,
                DestinationTown = customer1.City,
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
                ReceiverId = customer2.Id,
                DestinationAddress = customer2.Address,
                DestinationTown = customer2.City,
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
                ReceiverId = customer2.Id,
                DestinationAddress = customer2.Address,
                DestinationTown = customer2.City,
                DeliveryType = DeliveryType.StandardDeliveryService,
                ProductType = ProductType.Technique,
                Weight = 2.80,
                Price = 5.90M,
            },
            };

            // TODO: Shipment tracking path add
            await dbContext.Shipments.AddRangeAsync(shipments);
        }
    }
}
