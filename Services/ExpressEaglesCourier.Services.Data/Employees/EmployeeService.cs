namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepo;
        private readonly IDeletableEntityRepository<Office> officeRepo;
        private readonly IDeletableEntityRepository<Position> positionRepo;
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeeService(
            IDeletableEntityRepository<Employee> employeeRepo,
            IDeletableEntityRepository<Office> officeRepo,
            IDeletableEntityRepository<Position> positionRepo,
            IDeletableEntityRepository<Vehicle> vehicleRepo,
            UserManager<ApplicationUser> userManager)
        {
            this.employeeRepo = employeeRepo;
            this.officeRepo = officeRepo;
            this.positionRepo = positionRepo;
            this.vehicleRepo = vehicleRepo;
            this.userManager = userManager;
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
                DateOfBirth = model.DateOfBirth,
                HiredOn = model.HiredOn,
                Salary = model.Salary,
                ResignOn = model.ResignOn,
                OfficeId = model.OfficeId,
                PositionId = model.PositionId,
                VehicleId = model.VehicleId,
            };

            await this.employeeRepo.AddAsync(newEmployee);
            await this.employeeRepo.SaveChangesAsync();

            await this.AddRolesToEmployees(newEmployee);

            int vehicleId = newEmployee.VehicleId ?? 0;

            if (vehicleId != 0)
            {
                Vehicle vehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == vehicleId);
                vehicle.EmployeeId = newEmployee.Id;
                await this.vehicleRepo.SaveChangesAsync();
            }

            return newEmployee.Id;
        }

        public async Task AddRolesToEmployees(Employee employee)
        {
            if (employee.PositionId == 1 || employee.PositionId == 2
            || employee.PositionId == 3 || employee.PositionId == 5)
            {
                ApplicationUser dbUser = await this.userManager.FindByNameAsync(employee.FirstName + employee.LastName);
                ApplicationUser dbUserWithBirthDate = await this.userManager.FindByNameAsync(employee.FirstName + employee.LastName + employee.DateOfBirth.ToShortDateString().Replace("/", string.Empty));
                ApplicationUser user;
                if (dbUser == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = employee.FirstName + employee.LastName,
                        Email = employee.FirstName + employee.LastName + "@" + "expresseagles.com",
                    };
                }
                else if (dbUserWithBirthDate == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = employee.FirstName + employee.LastName + employee.DateOfBirth.ToShortDateString().Replace("/", string.Empty),
                        Email = employee.FirstName + employee.LastName + employee.DateOfBirth.ToShortDateString().Replace("/", string.Empty) + "@" + "expresseagles.com",
                    };
                }
                else
                {
                    user = new ApplicationUser()
                    {
                        UserName = employee.FirstName + employee.LastName + employee.DateOfBirth.ToShortDateString().Replace("/", string.Empty) + employee.HiredOn.ToShortDateString().Replace("/", string.Empty),
                        Email = employee.FirstName + employee.LastName + employee.DateOfBirth.ToShortDateString().Replace("/", string.Empty) + employee.HiredOn.ToShortDateString().Replace("/", string.Empty) + "@" + "expresseagles.com",
                    };
                }

                user.PhoneNumber = employee.PhoneNumber;
                user.EmployeeId = employee.Id;

                IdentityResult result = await this.userManager.CreateAsync(user);

                employee.ApplicationUserId = user.Id;
                employee.ApplicationUser = user;

                if (result.Succeeded)
                {
                    _ = employee.PositionId == 1 ? await this.userManager.AddToRoleAsync(user, ManagerRoleName) : await this.userManager.AddToRoleAsync(user, EmployeeRoleName);
                }
            }
        }

        public async Task<T> GetEmployeeDetailsById<T>(string employeeId)
        => await this.employeeRepo.AllAsNoTracking()
                .Where(x => x.Id == employeeId)
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<Employee> GetEmployeeById(string employeeId)
       => await this.employeeRepo.All().FirstOrDefaultAsync(x => x.Id == employeeId);

        public async Task EditEmployeeAsync(EmployeeFormModel model)
        {
            Employee employee = await this.GetEmployeeById(model.Id);

            if (employee == null)
            {
                throw new NullReferenceException(EmployeeNotExist);
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
            employee.DateOfBirth = model.DateOfBirth;
            employee.HiredOn = model.HiredOn;
            employee.Salary = model.Salary;
            employee.ResignOn = model.ResignOn;
            employee.OfficeId = model.OfficeId;
            employee.PositionId = model.PositionId;
            employee.VehicleId = model.VehicleId;

            await this.employeeRepo.SaveChangesAsync();

            await this.DeleteEmployeeApplicationUser(employee);

            await this.AddRolesToEmployees(employee);

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
                throw new NullReferenceException(EmployeeNotExist);
            }

            if (employee.VehicleId != null)
            {
                Vehicle vehicle = await this.vehicleRepo.All().FirstOrDefaultAsync(x => x.Id == employee.VehicleId);

                vehicle.EmployeeId = null;
                await this.vehicleRepo.SaveChangesAsync();
            }

            this.employeeRepo.Delete(employee);
            await this.employeeRepo.SaveChangesAsync();

            await this.DeleteEmployeeApplicationUser(employee);
        }

        public async Task DeleteEmployeeApplicationUser(Employee employee)
        {
            ApplicationUser user = await this.userManager.FindByIdAsync(employee.ApplicationUserId);

            if (user != null)
            {
                IdentityResult result = null;
                if (await this.userManager.IsInRoleAsync(user, ManagerRoleName))
                {
                    result = await this.userManager.RemoveFromRoleAsync(user, ManagerRoleName);
                }

                if (await this.userManager.IsInRoleAsync(user, EmployeeRoleName))
                {
                    result = await this.userManager.RemoveFromRoleAsync(user, EmployeeRoleName);
                }

                if (result.Succeeded)
                {
                    await this.userManager.DeleteAsync(user);
                }
            }
        }

        public Task<int> GetEmployeesCountAsync()
        {
            return this.employeeRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(int page = 1, int itemsPerPage = 3)
        {
            List<T> model = await this.employeeRepo.AllAsNoTracking()
                .OrderBy(x => x.Office.City.Name)
                .ThenBy(x => x.FirstName + " " + x.LastName)
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return model;
        }
    }
}
