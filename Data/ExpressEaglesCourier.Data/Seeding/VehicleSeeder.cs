namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class VehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Employee driverBs = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359888121210");
            Employee driverVn = await dbContext.Employees.FirstOrDefaultAsync(x => x.PhoneNumber == "00359888656565");

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

            Vehicle vehicle3 = new Vehicle()
            {
                Model = "Citroen Berlingo",
                PlateNumber = "A9876BB",
            };
            Vehicle vehicle4 = new Vehicle()
            {
                Model = "Peugeot Partner",
                PlateNumber = "A3131CC",
            };
            Vehicle vehicle5 = new Vehicle()
            {
                Model = "Opel Combo",
                PlateNumber = "B2896MH",
            };

            await dbContext.Vehicles.AddRangeAsync(vehicle1, vehicle2);
            await dbContext.Vehicles.AddRangeAsync(vehicle3, vehicle4, vehicle5);
        }
    }
}
