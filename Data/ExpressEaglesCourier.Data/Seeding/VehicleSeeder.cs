namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class VehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Employee driverBs = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359 888 121210");
            Employee driverVn = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359 888 656565");

            Vehicle vehicle1 = new Vehicle()
            {
                Model = "Renault Trafic",
                PlateNumber = "A3358CA",
                EmployeeId = driverBs.Id,
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Model = "Ford Transit",
                PlateNumber = "B6894CC",
                EmployeeId = driverVn.Id,
            };
            await dbContext.Vehicles.AddRangeAsync(vehicle1, vehicle2);
        }
    }
}
