namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ShipmentVehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.ShipmentsVehicles.AnyAsync())
            {
                return;
            }

            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 1,
                VehicleId = 1,
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 2,
                VehicleId = 1,
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 3,
                VehicleId = 1,
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 4,
                VehicleId = 2,
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 5,
                VehicleId = 2,
            });
            await dbContext.ShipmentsVehicles.AddAsync(new ShipmentVehicle
            {
                ShipmentId = 6,
                VehicleId = 2,
            });
        }
    }
}
