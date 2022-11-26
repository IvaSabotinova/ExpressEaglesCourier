namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepo;
        private readonly IDeletableEntityRepository<Office> officeRepo;
        private readonly IDeletableEntityRepository<Position> positionRepo;
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepo;

        public EmployeeService(
            IDeletableEntityRepository<Employee> employeeRepo,
            IDeletableEntityRepository<Office> officeRepo,
            IDeletableEntityRepository<Position> positionRepo,
            IDeletableEntityRepository<Vehicle> vehicleRepo)
        {
            this.employeeRepo = employeeRepo;
            this.officeRepo = officeRepo;
            this.positionRepo = positionRepo;
            this.vehicleRepo = vehicleRepo;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllOfficesDetailsAsKeyValuePairs()
        {
            return this.officeRepo.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    Office = $"{x.City.Country.Name}, {x.City.Name}, {x.Address}",
                })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Office));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllPositionsAsKeyValuePairs()
        {
            return this.positionRepo.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    Position = x.JobTitle,
                })
                .OrderBy(x => x.Id)
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Position));
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllVehiclesAsKeyValuePairs()
        {
            return this.vehicleRepo.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    ModelAndRegNumber = $"Car Model: {x.Model}, Car Plate Number: {x.PlateNumber}",
                })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.ModelAndRegNumber));
        }

        public async Task<bool> EmployeeExist(string firstName, string lastName, string phoneNumber)
        {
            return await this.employeeRepo.AllAsNoTracking().AnyAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber);
        }

        public async Task<string> CreateEmployeeAsync(EmployeeFormModel model)
        {
            if (await this.EmployeeExist(model.FirstName, model.LastName, model.PhoneNumber))
            {
                throw new ArgumentException(EmployeeExists);
            }

            Employee newEmployee = new Employee()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber,
                HiredOn = model.HiredOn,
                Salary = model.Salary,
                ResignOn = model.ResignOn,
                OfficeId = model.OfficeId,
                PositionId = model.PositionId,
                VehicleId = model.VehicleId ?? 0,
            };

            await this.employeeRepo.AddAsync(newEmployee);
            await this.employeeRepo.SaveChangesAsync();

            return newEmployee.Id;
        }

        public async Task<EmployeeDetailsViewModel> GetEmployeeDetails(string employeeId)
        {
            Employee employee = await this.employeeRepo.AllAsNoTracking()
                .Include(x => x.Position)
                .Include(x => x.Office)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .Include(x => x.Vehicle)
                .FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EmployeeNotExist);
            }

            return new EmployeeDetailsViewModel()
            {
                Id = employee.Id,
                FullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}",
                PhoneNumber = employee.PhoneNumber,
                Position = employee.Position.JobTitle,
                OfficeDetails = $"{employee.Office.Address}, {employee.Office.City.Name}, {employee.Office.City.Country.Name}",
                VehicleDetails = $"{employee.Vehicle?.Model}, {employee.Vehicle?.PlateNumber}" ?? null,
            };
        }

        public async Task<IEnumerable<EmployeeAllViewModel>> GetAllAsync(int shipmentId)
        {
            List<Employee> employees = await this.employeeRepo.AllAsNoTracking()
               .Include(x => x.Position)
               .Include(x => x.Vehicle)
               .Include(x => x.Office)
               .ThenInclude(x => x.City)
               .ToListAsync();

            List<EmployeeAllViewModel> model = employees.Select(x => new EmployeeAllViewModel()
            {
                Id = x.Id,
                FullName = $"{x.FirstName} {x.LastName}",
                Position = x.Position.JobTitle,
                PhoneNumber = x.PhoneNumber,
                OfficeCity = x.Office.City.Name,
                ShipmentId = shipmentId,
                Vehicle = new VehicleEmployeeViewModel()
                {
                    Id = x.Vehicle?.Id ?? 0,
                    Model = x.Vehicle?.Model ?? null,
                    PlateNumber = x.Vehicle?.PlateNumber ?? null,
                },
            }).OrderBy(x => x.OfficeCity)
               .ToList();

            return model;
        }
    }
}
