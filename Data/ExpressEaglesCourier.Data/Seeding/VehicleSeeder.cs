namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class VehicleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            Vehicle vehicle1 = new Vehicle()
            {
                Model = "Renault Trafic",
                PlateNumber = "A3358CA",
                EmployeeId = "8600e792-3aab-4bb9-8510-dda0cd320bd9",
            };
            Vehicle vehicle2 = new Vehicle()
            {
                Model = "Ford Transit",
                PlateNumber = "B6894CC",
                EmployeeId = "1a5c7364-6618-4210-b7aa-8992b287ffaa",
            };
            await dbContext.Vehicles.AddRangeAsync(vehicle1, vehicle2);

            Employee driverBs = dbContext.Employees.Find("8600e792-3aab-4bb9-8510-dda0cd320bd9");
            Employee driverVn = dbContext.Employees.Find("1a5c7364-6618-4210-b7aa-8992b287ffaa");
            driverBs.VehicleId = vehicle1.Id;
            driverVn.VehicleId = vehicle2.Id;
        }
    }
}
