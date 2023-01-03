namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.Stats;
    using ExpressEaglesCourier.Web.ViewModels.Administration.Dashboard;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.StaffBoard;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class StatsServiceTests
    {
        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestStats");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
        }

        public CustomerService GetCustomerService()
        {
            EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

            CustomerService customerService = new CustomerService(customerRepo);
            return customerService;
        }

        public ShipmentService GetShipmentService()
        {
            EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

            EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

            EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

            EfDeletableEntityRepository<EmployeeShipment> employeeShipmentRepo = new EfDeletableEntityRepository<EmployeeShipment>(this.GetDbContext());

            EfDeletableEntityRepository<ShipmentVehicle> shipmentVehicleRepo = new EfDeletableEntityRepository<ShipmentVehicle>(this.GetDbContext());

            EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

            EfDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo = new EfDeletableEntityRepository<ShipmentTrackingPath>(this.GetDbContext());

            ShipmentService shipmentService = new ShipmentService(shipmentRepo, customerRepo, employeeRepo, employeeShipmentRepo, shipmentVehicleRepo, vehicleRepo, shipmentTrackingPathRepo);
            return shipmentService;
        }

        public StatsService GetStatsService()
        {
            {
                EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

                EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

                EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

                EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

                EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

                EfDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo = new EfDeletableEntityRepository<ShipmentTrackingPath>(this.GetDbContext());

                StatsService statsService = new StatsService(officeRepo, employeeRepo, vehicleRepo, customerRepo, shipmentRepo, shipmentTrackingPathRepo);

                return statsService;
            }
        }

        public CustomerFormModel GetCustomer1FormModel()
        {
            CustomerFormModel model = new CustomerFormModel()
            {
                FirstName = "Pesho",
                MiddleName = "Goshev",
                LastName = "Goshev",
                Address = "Lazur block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359999333333",
            };

            return model;
        }

        public CustomerFormModel GetCustomer2FormModel()
        {
            CustomerFormModel model = new CustomerFormModel()
            {
                FirstName = "Vlado",
                MiddleName = "Vladev",
                LastName = "Vladev",
                Address = "Vl. Varnenchik block 15",
                City = "Varna",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359999999999",
            };

            return model;
        }

        [Fact]
        public async Task OfficesCountAsyncTest()
        {
            int officesCount = await this.GetStatsService().OfficesCountAsync();

            Assert.Equal(0, officesCount);
        }

        [Fact]
        public async Task EmployeesCountAsyncTest()
        {
            int employeesCount = await this.GetStatsService().EmployeesCountAsync();
            Assert.Equal(0, employeesCount);
        }

        [Fact]
        public async Task VehiclesCountAsyncTest()
        {
            int vehiclesCount = await this.GetStatsService().VehiclesCountAsync();
            Assert.Equal(0, vehiclesCount);
        }

        [Fact]

        public async Task CustomersCountAndShipmentsCountAndGetStatsAndGetProductTypeStatsTests()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers
                .Where(x => x.PhoneNumber == "00359999333333").FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers
                .Where(x => x.PhoneNumber == "00359999999999").FirstOrDefaultAsync();

            int customersCount = await this.GetStatsService().CustomersCountAsync();

            ShipmentFormModel shipmentModel1 = new ShipmentFormModel()
            {
                TrackingNumber = "22222222222",
                SenderFirstName = customer1.FirstName,
                SenderLastName = customer1.LastName,
                SenderPhoneNumber = customer1.PhoneNumber,
                ReceiverFirstName = customer2.FirstName,
                ReceiverLastName = customer2.LastName,
                ReceiverPhoneNumber = customer2.PhoneNumber,
                PickUpAddress = customer1.Address,
                PickUpTown = customer1.City,
                PickUpCountry = customer1.Country,
                DestinationAddress = customer2.Address,
                DestinationTown = customer2.City,
                DestinationCountry = customer2.Country,
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
            };
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel1);

            ShipmentFormModel shipmentModel2 = new ShipmentFormModel()
            {
                TrackingNumber = "11111122221",
                SenderFirstName = customer1.FirstName,
                SenderLastName = customer1.LastName,
                SenderPhoneNumber = customer1.PhoneNumber,
                ReceiverFirstName = customer2.FirstName,
                ReceiverLastName = customer2.LastName,
                ReceiverPhoneNumber = customer2.PhoneNumber,
                PickUpAddress = customer1.Address,
                PickUpTown = customer1.City,
                PickUpCountry = customer1.Country,
                DestinationAddress = "Any Address",
                DestinationTown = "Varna",
                DestinationCountry = "Bulgaria",
                Weight = 0.30,
                DeliveryWay = (DeliveryWay)1,
                DeliveryType = 0,
                ProductType = (ProductType)2,
                Price = 4.90m,
            };

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel2);

            int shipmentsCount = await this.GetStatsService().ShipmentsCountAsync();

            DashboardViewModel model = await this.GetStatsService().GetStatsAsync();

            ShipmentProductTypeViewModel modelProductTypes = await this.GetStatsService().GetProductTypeStats();

            int textileShipmentsCount = await this.GetDbContext()
                .Shipments.Where(x => x.ProductType == ProductType.Textile).CountAsync();
            double percentageTextileShipments = (double)textileShipmentsCount / shipmentsCount * 100.00;

            int stationeriesShipmentsCount = await this.GetDbContext()
                .Shipments.Where(x => x.ProductType == ProductType.Stationeries).CountAsync();
            double percentageStationeriesShipments = (double)stationeriesShipmentsCount / shipmentsCount * 100.00;

            Assert.Equal(2, customersCount);

            Assert.Equal(2, shipmentsCount);

            Assert.Equal(2, model.CustomersCount);

            Assert.Equal(2, model.ShipmentsCount);

            Assert.Equal(percentageTextileShipments.ToString("f2", CultureInfo.InvariantCulture), modelProductTypes.Textile);

            Assert.Equal(percentageStationeriesShipments.ToString("f2", CultureInfo.InvariantCulture), modelProductTypes.Stationeries);
        }

        [Fact]
        public async Task ShipmentsTrackingPathsCountAsyncTest()
        {
            int shipmentTrackingPathsCount = await this.GetStatsService().ShipmentsTrackingPathsCountAsync();

            Assert.Equal(0, shipmentTrackingPathsCount);
        }
    }
}
