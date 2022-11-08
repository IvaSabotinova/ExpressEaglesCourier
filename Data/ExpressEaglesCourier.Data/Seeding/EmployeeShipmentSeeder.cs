namespace ExpressEaglesCourier.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;

    public class EmployeeShipmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "29e5c1c5-e8e4-438f-b861-f5bb6e89f28d",
                EmployeeId = "1ad04331-bf6a-4873-acfc-bd3d05bcc736",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "29e5c1c5-e8e4-438f-b861-f5bb6e89f28d",
                EmployeeId = "8600e792-3aab-4bb9-8510-dda0cd320bd9",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "4117d869-77d4-4234-9e5b-de6b3bf4d32d",
                EmployeeId = "5c7ea6fb-55c3-43d7-adfd-d7026b2fa95d",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "4117d869-77d4-4234-9e5b-de6b3bf4d32d",
                EmployeeId = "8600e792-3aab-4bb9-8510-dda0cd320bd9",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "60d3cd0a-8950-4f2f-9b9d-38ff9305d2fa",
                EmployeeId = "5c7ea6fb-55c3-43d7-adfd-d7026b2fa95d",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "60d3cd0a-8950-4f2f-9b9d-38ff9305d2fa",
                EmployeeId = "8600e792-3aab-4bb9-8510-dda0cd320bd9",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "8c503681-2e32-405c-bd7e-a0cb093be9b6",
                EmployeeId = "c17e060c-ec97-4042-bff0-0ab7f1407501",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "8c503681-2e32-405c-bd7e-a0cb093be9b6",
                EmployeeId = "1a5c7364-6618-4210-b7aa-8992b287ffaa",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "a18cc43c-91bd-4e09-826c-ab680f337d9a",
                EmployeeId = "f0d0cc14-fc58-49c3-844b-a9fd9bbc46e1",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "a18cc43c-91bd-4e09-826c-ab680f337d9a",
                EmployeeId = "1a5c7364-6618-4210-b7aa-8992b287ffaa",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "d01a24bb-670e-4464-a512-15c4c3f2d7ce",
                EmployeeId = "c17e060c-ec97-4042-bff0-0ab7f1407501",
            });
            await dbContext.EmployeesShipments.AddAsync(new EmployeeShipment
            {
                ShipmentId = "d01a24bb-670e-4464-a512-15c4c3f2d7ce",
                EmployeeId = "1a5c7364-6618-4210-b7aa-8992b287ffaa",
            });

        }
    }
}
