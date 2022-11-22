namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepo;

        public EmployeeService(IDeletableEntityRepository<Employee> employeeRepo)
        {
            this.employeeRepo = employeeRepo;
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
