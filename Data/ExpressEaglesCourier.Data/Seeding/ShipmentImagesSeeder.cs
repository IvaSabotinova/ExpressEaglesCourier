namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentImagesSeeder : ISeeder
    {
       public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.ShipmentImages.AnyAsync())
            {
                return;
            }

            Shipment shipmentCarParts = await dbContext.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == "11111011017");
            Shipment shipmentTextile = await dbContext.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == "11111011013");
            Shipment shipmentFurniture = await dbContext.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == "11111011019");
            Shipment shipmentStationeries = await dbContext.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == "11111011018");
            Shipment shipmentTechnique = await dbContext.Shipments
                .FirstOrDefaultAsync(x => x.TrackingNumber == "11111011016");

            List<ShipmentImage> shipmentImages = new List<ShipmentImage>()
            {
            new ShipmentImage()
            {
                Id = "14875e09-39a6-43b7-840a-36a84e8b1541",
                Extension = "jpg",
                Size = 36274,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "188657da-16c4-4bdc-8df1-1857cd05d9be",
                Extension = "jpg",
                Size = 51311,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "196f19c7-57d8-4a66-b65a-1010549eebac",
                Extension = "jpg",
                Size = 75665,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "1a6b5430-43f2-438e-94c9-eae9ace927f0",
                Extension = "jpg",
                Size = 288535,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "355b5a0f-df4a-4b37-a149-665bb9bd0a14",
                Extension = "jpg",
                Size = 98534,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "35d96c84-60c6-48e2-bc4b-bed2d09f0f0d",
                Extension = "png",
                Size = 4425590,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "762325bc-adf9-465e-b80b-5ba709a4e25c",
                Extension = "jpg",
                Size = 91189,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "8cc827b8-55f8-415f-be23-b8c74061da6f",
                Extension = "jpg",
                Size = 41958,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "eb6e0685-fa94-41c4-b1aa-022d6fd62147",
                Extension = "jpg",
                Size = 41908,
                ShipmentId = shipmentCarParts.Id,
            },
            new ShipmentImage()
            {
                Id = "6d426b84-0534-4070-8ef0-355dfeefa1ef",
                Extension = "jpg",
                Size = 8887,
                ShipmentId = shipmentFurniture.Id,
            },
            new ShipmentImage()
            {
                Id = "cffb85ae-171b-4c03-a07e-6ff864a532f5",
                Extension = "jpg",
                Size = 132841,
                ShipmentId = shipmentFurniture.Id,
            },
            new ShipmentImage()
            {
                Id = "e101c6eb-090f-44b5-93c7-97ce17a88df3",
                Extension = "jpg",
                Size = 163891,
                ShipmentId = shipmentFurniture.Id,
            },
            new ShipmentImage()
            {
                Id = "17344a6e-b37e-4a3e-b6c2-ad0bcdf21b80",
                Extension = "webp",
                Size = 1110958,
                ShipmentId = shipmentStationeries.Id,
            },
            new ShipmentImage()
            {
                Id = "3b683660-c085-495a-882f-6cb00dca1c08",
                Extension = "jpg",
                Size = 121984,
                ShipmentId = shipmentStationeries.Id,
            },
            new ShipmentImage()
            {
                Id = "8633d8e4-98c6-430b-adf8-49efd9cf59f6",
                Extension = "webp",
                Size = 1281752,
                ShipmentId = shipmentStationeries.Id,
            },
            new ShipmentImage()
            {
                Id = "3c7b2029-6b39-4664-a924-4219ec35f8b1",
                Extension = "png",
                Size = 471952,
                ShipmentId = shipmentTextile.Id,
            },
            new ShipmentImage()
            {
                Id = "3dbe6b95-1965-4b41-8479-779b620db74b",
                Extension = "jpg",
                Size = 58699,
                ShipmentId = shipmentTextile.Id,
            },
            new ShipmentImage()
            {
                Id = "8241ca32-7bd3-4819-b1f2-039614d61d36",
                Extension = "webp",
                Size = 3234,
                ShipmentId = shipmentTextile.Id,
            },
            new ShipmentImage()
            {
                Id = "9dad55d0-e8db-4a2e-bebe-1286202b6eef",
                Extension = "jpg",
                Size = 11691,
                ShipmentId = shipmentTechnique.Id,
            },
            };

            await dbContext.ShipmentImages.AddRangeAsync(shipmentImages);
        }
    }
}
