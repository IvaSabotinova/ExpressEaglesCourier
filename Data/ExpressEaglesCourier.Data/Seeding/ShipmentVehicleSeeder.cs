namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    internal class ShipmentVehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "29e5c1c5-e8e4-438f-b861-f5bb6e89f28d",
                VehicleId = "438747f3-5135-4b62-8ee5-6e84065b8698",
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "4117d869-77d4-4234-9e5b-de6b3bf4d32d",
                VehicleId = "438747f3-5135-4b62-8ee5-6e84065b8698",
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "60d3cd0a-8950-4f2f-9b9d-38ff9305d2fa",
                VehicleId = "438747f3-5135-4b62-8ee5-6e84065b8698",
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "8c503681-2e32-405c-bd7e-a0cb093be9b6",
                VehicleId = "6e5c6763-7636-4246-a103-ca40f2f6be5d",
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "a18cc43c-91bd-4e09-826c-ab680f337d9a",
                VehicleId = "6e5c6763-7636-4246-a103-ca40f2f6be5d",
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = "d01a24bb-670e-4464-a512-15c4c3f2d7ce",
                VehicleId = "6e5c6763-7636-4246-a103-ca40f2f6be5d",
            });


        }
    }
}
