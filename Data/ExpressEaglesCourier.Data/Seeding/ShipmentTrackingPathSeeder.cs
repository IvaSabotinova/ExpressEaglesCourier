namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentTrackingPathSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Shipment shipment1 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011010");
            Shipment shipment2 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011012");
            Shipment shipment3 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011013");
            Shipment shipment4 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011011");
            Shipment shipment5 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011015");
            Shipment shipment6 = await dbContext.Shipments.FirstOrDefaultAsync(x => x.TrackingNumber == "11111011016");

            ShipmentTrackingPath shipmentTrackingPath1 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment1.Id,
                TrackingNumber = shipment1.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath2 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment2.Id,
                TrackingNumber = shipment2.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath3 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment3.Id,
                TrackingNumber = shipment3.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("10-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("10-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath4 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment4.Id,
                TrackingNumber = shipment4.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath5 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment5.Id,
                TrackingNumber = shipment5.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath6 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment6.Id,
                TrackingNumber = shipment6.TrackingNumber,
                PickedUpByCourier = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("10-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("10-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };

            await dbContext.ShipmentsTrackingPath.AddRangeAsync(
                shipmentTrackingPath1,
                shipmentTrackingPath2,
                shipmentTrackingPath3,
                shipmentTrackingPath4,
                shipmentTrackingPath5,
                shipmentTrackingPath6);
        }
    }
}
