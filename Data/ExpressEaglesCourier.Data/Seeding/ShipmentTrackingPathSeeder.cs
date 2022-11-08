namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class ShipmentTrackingPathSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Shipment shipment1 = dbContext.Shipments.Find("29e5c1c5-e8e4-438f-b861-f5bb6e89f28d");
            Shipment shipment2 = dbContext.Shipments.Find("4117d869-77d4-4234-9e5b-de6b3bf4d32d");
            Shipment shipment3 = dbContext.Shipments.Find("60d3cd0a-8950-4f2f-9b9d-38ff9305d2fa");
            Shipment shipment4 = dbContext.Shipments.Find("8c503681-2e32-405c-bd7e-a0cb093be9b6");
            Shipment shipment5 = dbContext.Shipments.Find("a18cc43c-91bd-4e09-826c-ab680f337d9a");
            Shipment shipment6 = dbContext.Shipments.Find("d01a24bb-670e-4464-a512-15c4c3f2d7ce");

            ShipmentTrackingPath shipmentTrackingPath1 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment1.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath2 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment2.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("09-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath3 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment3.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath4 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment4.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath5 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment5.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };
            ShipmentTrackingPath shipmentTrackingPath6 = new ShipmentTrackingPath()
            {
                ShipmentId = shipment6.Id,
                PickedUpByCourier = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SentFromDispatchingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                ArrivalInReceivingOffice = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDeliveryPreparation = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
                FinalDelivery = DateTime.ParseExact("08-11-2022", "dd-MM-yyyy", CultureInfo.InvariantCulture),
            };

            await dbContext.ShipmentsTrackingPath.AddRangeAsync(
                shipmentTrackingPath1,
                shipmentTrackingPath2,
                shipmentTrackingPath3,
                shipmentTrackingPath4,
                shipmentTrackingPath5,
                shipmentTrackingPath6);

            shipment1.ShipmentTrackingPathId = shipmentTrackingPath1.Id;
            shipment2.ShipmentTrackingPathId = shipmentTrackingPath2.Id;
            shipment3.ShipmentTrackingPathId = shipmentTrackingPath3.Id;
            shipment4.ShipmentTrackingPathId = shipmentTrackingPath4.Id;
            shipment5.ShipmentTrackingPathId = shipmentTrackingPath5.Id;
            shipment6.ShipmentTrackingPathId = shipmentTrackingPath6.Id;
        }
    }
}
