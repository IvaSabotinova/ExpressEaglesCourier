namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class EmployeeShipmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            string employee1BsId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 898 331456").Id;
            string employee2BsId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 888 658974").Id;
            string driverBsId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 888 121210").Id;
            string employee1VnId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 888 333333").Id;
            string employee2VnId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 899 313131").Id;
            string driverVnId = dbContext.Employees.FirstOrDefault(x => x.PhoneNumber == "00359 888 656565").Id;
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 1,
                EmployeeId = employee1BsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 1,
                EmployeeId = driverBsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 2,
                EmployeeId = employee2BsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 2,
                EmployeeId = driverBsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 3,
                EmployeeId = employee1BsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 3,
                EmployeeId = driverBsId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 4,
                EmployeeId = employee1VnId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 4,
                EmployeeId = driverVnId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 5,
                EmployeeId = employee2VnId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 5,
                EmployeeId = driverVnId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 6,
                EmployeeId = employee1VnId,
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = 6,
                EmployeeId = driverVnId,
            });
        }
    }
}
