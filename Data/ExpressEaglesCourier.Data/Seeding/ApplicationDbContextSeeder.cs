namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              // new RolesSeeder(),

                              // new CountrySeeder(),
                              // new CitySeeder(),
                              // new OfficeSeeder(),
                              // new PositionSeeder(),
                              // new EmployeeSeeder(),
                              // new VehicleSeeder(),
                              // new CustomerSeeder(),
                               // new ShipmentSeeder(),
                              // new ShipmentTrackingPathSeeder(),
                              // new EmployeeShipmentSeeder(),
                              // new ShipmentVehicleSeeder(),
                              // new EmployeeVehicleSeeder(),
                              // new ShipmentShipmentTrackingPathSeeder(),
                              // new AdminSeeder(),
                             // new StaffUsersSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
