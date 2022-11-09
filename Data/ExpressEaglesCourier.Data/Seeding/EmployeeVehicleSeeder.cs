namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeVehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Employee driverBsId = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359 888 121210");
            Employee driverVnId = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359 888 656565");

            driverBsId.VehicleId = 1;
            driverVnId.VehicleId = 2;
        }
    }
}
