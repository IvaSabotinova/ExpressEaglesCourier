namespace ExpressEaglesCourier.Services.Data.Stats
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Web.ViewModels.Administration.Dashboard;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.StaffBoard;
    using Microsoft.EntityFrameworkCore;

    public class StatsService : IStatsService
    {
        private readonly IDeletableEntityRepository<Office> officeRepo;
        private readonly IDeletableEntityRepository<Employee> employeeRepo;
        private readonly IDeletableEntityRepository<Vehicle> vehicleRepo;
        private readonly IDeletableEntityRepository<Customer> customerRepo;
        private readonly IDeletableEntityRepository<Shipment> shipmentRepo;
        private readonly IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo;

        public StatsService(
            IDeletableEntityRepository<Office> officeRepo,
            IDeletableEntityRepository<Employee> employeeRepo,
            IDeletableEntityRepository<Vehicle> vehicleRepo,
            IDeletableEntityRepository<Customer> customerRepo,
            IDeletableEntityRepository<Shipment> shipmentRepo,
            IDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo)
        {
            this.officeRepo = officeRepo;
            this.employeeRepo = employeeRepo;
            this.vehicleRepo = vehicleRepo;
            this.customerRepo = customerRepo;
            this.shipmentRepo = shipmentRepo;
            this.shipmentTrackingPathRepo = shipmentTrackingPathRepo;
        }

        public async Task<int> OfficesCountAsync()
        {
            return await this.officeRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<int> EmployeesCountAsync()
        {
            return await this.employeeRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<int> VehiclesCountAsync()
        {
            return await this.vehicleRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<int> CustomersCountAsync()
        {
            return await this.customerRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<int> ShipmentsCountAsync()
        {
            return await this.shipmentRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<int> ShipmentsTrackingPathsCountAsync()
        {
            return await this.shipmentTrackingPathRepo.AllAsNoTracking().CountAsync();
        }

        public async Task<DashboardViewModel> GetStatsAsync()
        {
            return new DashboardViewModel()
            {
                OfficesCount = await this.OfficesCountAsync(),
                VehiclesCount = await this.VehiclesCountAsync(),
                EmployeesCount = await this.EmployeesCountAsync(),
                CustomersCount = await this.CustomersCountAsync(),
                ShipmentsCount = await this.ShipmentsCountAsync(),
                TrackingPathsCount = await this.ShipmentsTrackingPathsCountAsync(),
            };
        }

        public async Task<ShipmentProductTypeViewModel> GetProductTypeStats()
        {
            double carParts = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.CarParts).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double documents = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Documents).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double stationeries = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Stationeries).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double furniture = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Furniture).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double textile = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Textile).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double medicaments = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Medicaments).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;
            double technique = (double)await this.shipmentRepo.AllAsNoTracking()
                .Where(x => x.ProductType == ProductType.Technique).CountAsync()
                / await this.ShipmentsCountAsync() * 100.00;

            ShipmentProductTypeViewModel model = new ShipmentProductTypeViewModel()
            {
                CarParts = carParts.ToString("f2", CultureInfo.InvariantCulture),
                Documents = documents.ToString("f2", CultureInfo.InvariantCulture),
                Stationeries = stationeries.ToString("f2", CultureInfo.InvariantCulture),
                Furniture = furniture.ToString("f2", CultureInfo.InvariantCulture),
                Textile = textile.ToString("f2", CultureInfo.InvariantCulture),
                Medicaments = medicaments.ToString("f2", CultureInfo.InvariantCulture),
                Technique = technique.ToString("f2", CultureInfo.InvariantCulture),
            };

            return model;
        }
    }
}
