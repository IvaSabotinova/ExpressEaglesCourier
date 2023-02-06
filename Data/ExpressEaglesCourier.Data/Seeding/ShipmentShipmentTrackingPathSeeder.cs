namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentShipmentTrackingPathSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Shipments.AnyAsync(x => x.ShipmentTrackingPathId != null))
            {
                return;
            }

            Shipment shipment1 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011010");
            Shipment shipment2 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011012");
            Shipment shipment3 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011013");
            Shipment shipment4 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011011");
            Shipment shipment5 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011015");
            Shipment shipment6 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011016");

            shipment1.ShipmentTrackingPathId = 1;
            shipment2.ShipmentTrackingPathId = 2;
            shipment3.ShipmentTrackingPathId = 3;
            shipment4.ShipmentTrackingPathId = 4;
            shipment5.ShipmentTrackingPathId = 5;
            shipment6.ShipmentTrackingPathId = 6;
        }
    }
}
