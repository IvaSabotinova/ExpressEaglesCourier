namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class SearchServiceTests
    {
        private Mock<UserManager<ApplicationUser>> mockUserManager;

        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestSearch");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
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

            EfDeletableEntityRepository<ShipmentImage> shipmentImageRepo = new EfDeletableEntityRepository<ShipmentImage>(this.GetDbContext());

            ShipmentService shipmentService = new ShipmentService(shipmentRepo, customerRepo, employeeRepo, employeeShipmentRepo, shipmentVehicleRepo, vehicleRepo, shipmentTrackingPathRepo, shipmentImageRepo);
            return shipmentService;
        }

        public ShipmentTrackingPathService GetShipmentTrackingPathService()
        {
            EfDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo = new EfDeletableEntityRepository<ShipmentTrackingPath>(this.GetDbContext());

            EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

            EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

            ShipmentTrackingPathService shipmentTrackingPathService = new ShipmentTrackingPathService(shipmentTrackingPathRepo, shipmentRepo, officeRepo);
            return shipmentTrackingPathService;
        }

        public EmployeeService GetEmployeeService()
        {
            EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

            EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

            EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(this.GetDbContext());

            EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

            this.mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            EmployeeService employeeService = new EmployeeService(employeeRepo, officeRepo, positionRepo, vehicleRepo, this.mockUserManager.Object);

            return employeeService;
        }

        public CustomerService GetCustomerService()
        {
            EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

            CustomerService customerService = new CustomerService(customerRepo);
            return customerService;
        }

        public SearchService GetSearchService()
        {
        EfDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo = new EfDeletableEntityRepository<ShipmentTrackingPath>(this.GetDbContext());

        EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

        EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

        EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

        SearchService searchService = new SearchService(
            shipmentTrackingPathRepo,
            this.GetShipmentTrackingPathService(),
            shipmentRepo,
            this.GetShipmentService(),
            employeeRepo,
            this.GetEmployeeService(),
            customerRepo,
            this.GetCustomerService());
        return searchService;
        }

        public async Task<Customer> GetCustomer1()
        {
            CustomerFormModel customerModel1 = new CustomerFormModel()
            {
                FirstName = "Velko",
                MiddleName = "Goshev",
                LastName = "Goshev",
                Address = "Lazur block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00333333333333",
            };

            await this.GetCustomerService().CreateCustomerAsync(customerModel1);

            Customer customer1 = await this.GetDbContext().Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00333333333333");
            return customer1;
        }

        public async Task<Customer> GetCustomer2()
        {
            CustomerFormModel customerModel2 = new CustomerFormModel()
            {
                FirstName = "Stancho",
                MiddleName = "Stanev",
                LastName = "Stanev",
                Address = "Vl. Varnenchik block 9",
                City = "Varna",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00222222222222",
            };

            await this.GetCustomerService().CreateCustomerAsync(customerModel2);

            Customer customer2 = await this.GetDbContext().Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00222222222222");

            return customer2;
        }

        [Fact]

        public async Task SearchTrackingPathAsyncTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111127",
                SenderFirstName = this.GetCustomer1().Result.FirstName,
                SenderLastName = this.GetCustomer1().Result.LastName,
                SenderPhoneNumber = this.GetCustomer1().Result.PhoneNumber,
                ReceiverFirstName = this.GetCustomer2().Result.FirstName,
                ReceiverLastName = this.GetCustomer2().Result.LastName,
                ReceiverPhoneNumber = this.GetCustomer2().Result.PhoneNumber,
                PickUpAddress = this.GetCustomer1().Result.Address,
                PickUpTown = this.GetCustomer1().Result.City,
                PickUpCountry = this.GetCustomer1().Result.Country,
                DestinationAddress = this.GetCustomer2().Result.Address,
                DestinationTown = this.GetCustomer2().Result.City,
                DestinationCountry = this.GetCustomer2().Result.Country,
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
            };

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == shipmentModel.TrackingNumber).FirstOrDefaultAsync();

            ShipmentTrackingPathFormModel shipmentTrackingPathModel = new ShipmentTrackingPathFormModel()
            {
                ShipmentId = shipment.Id,
                TrackingNumber = shipment.TrackingNumber,
                AcceptanceFromCustomer = DateTime.Now.AddDays(-2),
                PickedUpByCourier = DateTime.Now.AddDays(-2),
                SendingOfficeId = 1,
                SentFromDispatchingOffice = DateTime.Now.AddDays(-2),
                ReceivingOfficeId = 3,
                ArrivalInReceivingOffice = DateTime.Now.AddDays(-2),
                FinalDeliveryPreparation = DateTime.Now.AddDays(-2),
                FinalDelivery = DateTime.Now.AddDays(-2),
            };

            await this.GetShipmentTrackingPathService().CreateShipmentTrackingPathAsync(shipmentTrackingPathModel);

            ShipmentTrackingPathDetailsModel model = await this.GetSearchService().SearchTrackingPathAsync(shipment.TrackingNumber);

            Assert.NotNull(model);
        }

        [Fact]

        public async Task SearchTrackingPathAsyncExceptionTest()
        {
            ShipmentTrackingPathDetailsModel model = await this.GetSearchService().SearchTrackingPathAsync("001001001001");

            Assert.Null(model);
        }

        [Fact]

        public async Task SearchShipmentByTrackingNumberAsyncTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111128",
                SenderFirstName = this.GetCustomer1().Result.FirstName,
                SenderLastName = this.GetCustomer1().Result.LastName,
                SenderPhoneNumber = this.GetCustomer1().Result.PhoneNumber,
                ReceiverFirstName = this.GetCustomer2().Result.FirstName,
                ReceiverLastName = this.GetCustomer2().Result.LastName,
                ReceiverPhoneNumber = this.GetCustomer2().Result.PhoneNumber,
                PickUpAddress = this.GetCustomer1().Result.Address,
                PickUpTown = this.GetCustomer1().Result.City,
                PickUpCountry = this.GetCustomer1().Result.Country,
                DestinationAddress = this.GetCustomer2().Result.Address,
                DestinationTown = this.GetCustomer2().Result.City,
                DestinationCountry = this.GetCustomer2().Result.Country,
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
            };

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == shipmentModel.TrackingNumber).FirstOrDefaultAsync();

            ShipmentDetailsViewModel model = await this.GetSearchService().SearchShipmentByTrackingNumberAsync(shipment.TrackingNumber);

            Assert.NotNull(model);
        }

        [Fact]
        public async Task SearchShipmentByTrackingNumberAsyncExceptionTest()
        {
            ShipmentDetailsViewModel model = await this.GetSearchService().SearchShipmentByTrackingNumberAsync("001001001001");

            Assert.Null(model);
        }

        [Fact]

        public async Task SearchEmployeeByPhoneNumberAsyncExceptionTest()
        {
            EmployeeDetailsViewModel model = await this.GetSearchService().SearchEmployeeByPhoneNumberAsync("001001001001");
            Assert.Null(model);
        }

        [Fact]

        public async Task SearchCustomerByPhoneNumberAsyncTest()
        {
            CustomerDetailsViewModel model = await this.GetSearchService().SearchCustomerByPhoneNumberAsync(this.GetCustomer1().Result.PhoneNumber);

            Assert.NotNull(model);
        }

        [Fact]

        public async Task SearchCustomerByPhoneNumberAsyncExceptionTest()
        {
            CustomerDetailsViewModel model = await this.GetSearchService().SearchCustomerByPhoneNumberAsync("01010101011");
            Assert.Null(model);
        }
    }
}
