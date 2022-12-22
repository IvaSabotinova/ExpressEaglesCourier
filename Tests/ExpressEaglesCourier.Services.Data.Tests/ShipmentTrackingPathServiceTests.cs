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
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Services.Data.ShipmentTrackingPaths;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ShipmentTrackingPathServiceTests
    {
        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestShipmentTrackingPath");
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

        public ShipmentTrackingPathService GetShipmentTrackingPathService()
        {
            EfDeletableEntityRepository<ShipmentTrackingPath> shipmentTrackingPathRepo = new EfDeletableEntityRepository<ShipmentTrackingPath>(this.GetDbContext());

            EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

            EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

            ShipmentTrackingPathService shipmentTrackingPathService = new ShipmentTrackingPathService(shipmentTrackingPathRepo, shipmentRepo, officeRepo);
            return shipmentTrackingPathService;
        }

        public async Task<Customer> GetCustomer1()
        {
            CustomerFormModel customerModel1 = new CustomerFormModel()
            {
                FirstName = "Martin",
                MiddleName = "Goshev",
                LastName = "Goshev",
                Address = "Lazur block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359999111111",
            };

            await this.GetCustomerService().CreateCustomerAsync(customerModel1);

            Customer customer1 = await this.GetDbContext().Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359999111111");
            return customer1;
        }

        public async Task<Customer> GetCustomer2()
        {
            CustomerFormModel customerModel2 = new CustomerFormModel()
            {
                FirstName = "Martin",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Vl. Varnenchik block 9",
                City = "Varna",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359999222222",
            };

            await this.GetCustomerService().CreateCustomerAsync(customerModel2);

            Customer customer2 = await this.GetDbContext().Customers
                .FirstOrDefaultAsync(x => x.PhoneNumber == "00359999222222");

            return customer2;
        }

        [Fact]
        public async Task GetShipmentByIdTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111119",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

            Shipment shipmentDb = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == shipmentModel.TrackingNumber).FirstOrDefaultAsync();

            Shipment shipment = await this.GetShipmentTrackingPathService().GetShipmentById(shipmentDb.Id);

            Assert.Equal(shipmentDb.TrackingNumber, shipment.TrackingNumber);
        }

        [Fact]

        public async Task GetShipmentByIdExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetShipmentTrackingPathService().GetShipmentById(8));
        }

        [Fact]
        public async Task CreateShipmentTrackingPathAsyncTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111120",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            ShipmentTrackingPath shipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath.FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            Assert.Equal(shipmentTrackingPathModel.TrackingNumber, shipmentTrackingPath.TrackingNumber);
        }

        [Fact]

        public async Task CreateShipmentTrackingPathAsyncWhenTrackingPathAlreadyExistsExceptionTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111130",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            await Assert.ThrowsAsync<ArgumentException>(() =>
                this.GetShipmentTrackingPathService().CreateShipmentTrackingPathAsync(shipmentTrackingPathModel));
        }

        [Fact]
        public async Task CreateShipmentTrackingPathAsyncExceptionTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111121",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == shipmentModel.TrackingNumber).FirstOrDefaultAsync();

            ShipmentTrackingPathFormModel shipmentTrackingPathModel = new ShipmentTrackingPathFormModel()
            {
                ShipmentId = shipment.Id,
                TrackingNumber = "10000000000",
                AcceptanceFromCustomer = DateTime.Now.AddDays(-2),
                PickedUpByCourier = DateTime.Now.AddDays(-2),
                SendingOfficeId = 1,
                SentFromDispatchingOffice = DateTime.Now.AddDays(-2),
                ReceivingOfficeId = 3,
                ArrivalInReceivingOffice = DateTime.Now.AddDays(-2),
                FinalDeliveryPreparation = DateTime.Now.AddDays(-2),
                FinalDelivery = DateTime.Now.AddDays(-2),
            };

            await Assert.ThrowsAsync<InvalidOperationException>(() => this.GetShipmentTrackingPathService().CreateShipmentTrackingPathAsync(shipmentTrackingPathModel));
        }

        [Fact]
        public async Task GetTrackingPathByIdTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111122",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            ShipmentTrackingPath shipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath.FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            ShipmentTrackingPath trackingPath = await this.GetShipmentTrackingPathService().GetTrackingPathById(shipmentTrackingPath.Id);

            Assert.Equal(shipmentTrackingPath.Id, trackingPath.Id);
        }

        [Fact]
        public async Task DetailsTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111123",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            ShipmentTrackingPath shipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath.FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            ShipmentTrackingPathDetailsModel model = await this.GetShipmentTrackingPathService()
                .Details(shipmentTrackingPath.Id);

            Assert.Equal(shipmentTrackingPath.AcceptanceFromCustomer, model.DateTimeAcceptanceFromCustomer);
        }

        [Fact]

        public async Task GetTrackingPathForUpdateTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111124",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            ShipmentTrackingPath shipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath.FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            ShipmentTrackingPathFormModel model = await this.GetShipmentTrackingPathService().GetTrackingPathForUpdate(shipmentTrackingPath.Id);

            Assert.NotNull(model);
            Assert.Equal(shipment.TrackingNumber, model.TrackingNumber);
        }

        [Fact]

        public async Task UpdateShipmentTrackingPathAsyncTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111126",
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

            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

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

            ShipmentTrackingPath shipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath.FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            ShipmentTrackingPathFormModel editModel = await this.GetShipmentTrackingPathService().GetTrackingPathForUpdate(shipmentTrackingPath.Id);

            await this.GetShipmentTrackingPathService().UpdateShipmentTrackingPathAsync(new ShipmentTrackingPathFormModel()
            {
                Id = editModel.Id,
                ShipmentId = editModel.ShipmentId,
                TrackingNumber = editModel.TrackingNumber,
                AcceptanceFromCustomer = DateTime.Now.AddDays(-2),
                PickedUpByCourier = DateTime.Now.AddDays(-2),
                SendingOfficeId = 1,
                SentFromDispatchingOffice = DateTime.Now.AddDays(-2),
                ReceivingOfficeId = 2,
                ArrivalInReceivingOffice = DateTime.Now.AddDays(-2),
                FinalDeliveryPreparation = DateTime.Now.AddDays(-2),
                FinalDelivery = DateTime.Now.AddDays(-2),
            });

            ShipmentTrackingPath updatedShipmentTrackingPath = await this.GetDbContext().ShipmentsTrackingPath
                .FirstOrDefaultAsync(x => x.TrackingNumber == shipment.TrackingNumber);

            Assert.Equal(2, updatedShipmentTrackingPath.ReceivingOfficeId);
        }
    }
}
