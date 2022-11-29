﻿namespace ExpressEaglesCourier.Services.Data.Employees
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

        public IEnumerable<KeyValuePair<string, string>> GetVehiclesAsKeyValuePairs()
        {
            return this.vehicleRepo.AllAsNoTracking()
                .Where(x => x.EmployeeId == null)
                .Select(x => new
                {
                    x.Id,
                    ModelAndRegNumber = $"Car Model: {x.Model}, Car Plate Number: {x.PlateNumber}",
                })
                .ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.ModelAndRegNumber));
        }

        public async Task<string> CreateEmployeeAsync(EmployeeFormModel model)
        {
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
                VehicleId = model.VehicleId,
            };

            await this.employeeRepo.AddAsync(newEmployee);
            await this.employeeRepo.SaveChangesAsync();

            int vehicleId = newEmployee.VehicleId ?? 0;

            if (vehicleId != 0)
            {
                Vehicle vehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == vehicleId);
                vehicle.EmployeeId = newEmployee.Id;
                await this.vehicleRepo.SaveChangesAsync();
            }

            return newEmployee.Id;
        }

        public async Task<EmployeeDetailsViewModel> GetEmployeeDetails(string employeeId)
        {
            Employee employee = await this.employeeRepo.AllAsNoTracking()
                .Include(x => x.Vehicle)
                .Include(x => x.Position)
                .Include(x => x.Office)
                .ThenInclude(x => x.City)
                .ThenInclude(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EmployeeNotExist);
            }

            EmployeeDetailsViewModel model = new EmployeeDetailsViewModel()
            {
                Id = employee.Id,
                FullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}",
                PhoneNumber = employee.PhoneNumber,
                Position = employee.Position.JobTitle,
                OfficeDetails = $"{employee.Office.Address}, {employee.Office.City.Name}, {employee.Office.City.Country.Name}",
                VehicleModel = employee.Vehicle?.Model ?? null,
                VehiclePlateNumber = employee.Vehicle?.PlateNumber ?? null,
            };

            return model;
        }

        public async Task<Employee> GetEmployeeById(string employeeId)
       => await this.employeeRepo.All().FirstOrDefaultAsync(x => x.Id == employeeId);

        public async Task<EmployeeFormModel> GetEmployeeForEditAsync(string employeeId)
        {
            Employee employee = await this.GetEmployeeById(employeeId);

            return new EmployeeFormModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Address = employee.Address,
                City = employee.City,
                Country = employee.Country,
                PhoneNumber = employee.PhoneNumber,
                HiredOn = employee.HiredOn,
                Salary = employee.Salary,
                ResignOn = employee.ResignOn,
                OfficeId = employee.OfficeId,
                PositionId = employee.PositionId,
                VehicleId = employee.VehicleId,
            };
        }

        public async Task EditEmployeeAsync(EmployeeFormModel model)
        {
            Employee employee = await this.GetEmployeeById(model.Id);

            if (employee == null)
            {
                throw new ArgumentException(EmployeeNotExist);
            }

            Vehicle employeeOldVehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == employee.VehicleId);
            Vehicle employeeNewVehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == model.VehicleId);

            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.Country = model.Country;
            employee.PhoneNumber = model.PhoneNumber;
            employee.HiredOn = model.HiredOn;
            employee.Salary = model.Salary;
            employee.ResignOn = model.ResignOn;
            employee.OfficeId = model.OfficeId;
            employee.PositionId = model.PositionId;
            employee.VehicleId = model.VehicleId;

            await this.employeeRepo.SaveChangesAsync();

            if (employeeOldVehicle != null)
            {
                employeeOldVehicle.EmployeeId = null;
            }

            if (employeeNewVehicle != null)
            {
                employeeNewVehicle.EmployeeId = employee.Id;
            }

            await this.vehicleRepo.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(string employeeId)
        {
            Employee employee = await this.GetEmployeeById(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EmployeeNotExist);
            }

            if (employee.VehicleId != null)
            {
                Vehicle vehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == employee.VehicleId);

                vehicle.EmployeeId = null;
                await this.vehicleRepo.SaveChangesAsync();
            }

            this.employeeRepo.Delete(employee);
            await this.employeeRepo.SaveChangesAsync();
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