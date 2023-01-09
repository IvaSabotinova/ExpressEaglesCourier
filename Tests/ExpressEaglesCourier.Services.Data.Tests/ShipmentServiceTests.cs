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
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employees;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ShipmentServiceTests
    {
        private Mock<UserManager<ApplicationUser>> mockUserManager;

        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestShipment");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
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

        public CustomerService GetCustomerService()
        {
            EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

            CustomerService customerService = new CustomerService(customerRepo);
            return customerService;
        }

        public CustomerFormModel GetCustomer1FormModel()
        {
            CustomerFormModel customerModel1 = new CustomerFormModel()
            {
                FirstName = "Gosho",
                MiddleName = "Goshev",
                LastName = "Marinov",
                Address = "Lazur block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359888111111",
            };

            return customerModel1;
        }

        public CustomerFormModel GetCustomer2FormModel()
        {
            CustomerFormModel customerModel2 = new CustomerFormModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Vl. Varnenchik block 9",
                City = "Varna",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359888222222",
            };

            return customerModel2;
        }

        public EmployeeFormModel GetEmployeeFormModel()
        {
            EmployeeFormModel model = new EmployeeFormModel()
            {
                FirstName = "Milen",
                MiddleName = "Milenov",
                LastName = "Milenov",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                HiredOn = DateTime.Now.AddDays(-2),
                PhoneNumber = "00359987654314",
                OfficeId = 1,
                PositionId = 8,
                VehicleId = null,
                ResignOn = null,
                Salary = 1200,
            };

            return model;
        }

        [Fact]

        public async Task CustomerWithPhoneNumberExistsTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            Assert.True(await this.GetShipmentService().CustomerWithPhoneNumberExists(customer.FirstName, customer.LastName, customer.PhoneNumber));
        }

        [Fact]

        public async Task CustomerWithPhoneNumberDoesntExistTest()
        {
            bool result = await this.GetShipmentService()
                .CustomerWithPhoneNumberExists("Kiril", "Kirilov", "020202020202");
            Assert.False(result);
        }

        [Fact]

        public async Task CustomerWithPhoneNumberExistsExceptionTest()
        {
            CustomerFormModel exceptionModel = new CustomerFormModel()
            {
                FirstName = "Vlad",
                MiddleName = "Vladov",
                LastName = "Vladov",
                Address = "Slaveikov block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359888333333",
            };

            Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync(x => x.PhoneNumber == "00359888888888");

            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetShipmentService().CustomerWithPhoneNumberExists(customer.FirstName, customer.LastName, customer.PhoneNumber));
        }

        [Fact]
        public async Task CreateShipmentTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetShipmentService().CustomerWithPhoneNumberExists(customer1.FirstName, customer1.LastName, customer1.PhoneNumber);

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            await this.GetShipmentService().CustomerWithPhoneNumberExists(customer2.FirstName, customer2.LastName, customer2.PhoneNumber);

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111111",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .LastOrDefaultAsync();

            bool result = await this.GetShipmentService().TrackingNumberExists(shipmentModel.TrackingNumber);

            string customer1Id = await this.GetShipmentService().GetCustomerId(customer1.FirstName, customer1.LastName, customer1.PhoneNumber);

            Assert.Equal(shipmentModel.TrackingNumber, shipment.TrackingNumber);
            Assert.True(result);
            Assert.Equal(customer1.Id, customer1Id);
        }

        [Fact]

        public async Task GetCustomerIdExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() =>
                this.GetShipmentService().GetCustomerId("Milen", "Peshov", "00222222222221"));
        }

        [Fact]

        public async Task GetShipmentForEditAsyncTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel model = new ShipmentFormModel()
            {
                TrackingNumber = "11111111112",
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
            await this.GetShipmentService().CreateShipmentAsync(model, null);

            Shipment shipment = await this.GetDbContext().Shipments.LastOrDefaultAsync();

            ShipmentFormModel editModel = await this.GetShipmentService()
                  .GetShipmentForEditAsync(shipment.Id);

            Assert.Equal(shipment.TrackingNumber, editModel.TrackingNumber);
            Assert.Equal(shipment.PickupAddress, editModel.PickUpAddress);
        }

        [Fact]
        public async Task GetShipmentForEditExceptionTest()
        {
            Shipment shipment = await this.GetDbContext().Shipments.Where(x => x.TrackingNumber == "00100100100").FirstOrDefaultAsync();

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            this.GetShipmentService().GetShipmentForEditAsync(shipment.Id));
        }

        [Fact]
        public async Task EditShipmentAsyncTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111113",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments.Where(x => x.TrackingNumber == "11111111113").FirstOrDefaultAsync();

            ShipmentFormModel editModel = await this.GetShipmentService()
                .GetShipmentForEditAsync(shipment.Id);

            await this.GetShipmentService().EditShipmentAsync(
                new ShipmentFormModel()
                {
                Id = editModel.Id,
                TrackingNumber = editModel.TrackingNumber,
                SenderFirstName = customer1.FirstName,
                SenderLastName = customer1.LastName,
                SenderPhoneNumber = customer1.PhoneNumber,
                ReceiverFirstName = customer2.FirstName,
                ReceiverLastName = customer2.LastName,
                ReceiverPhoneNumber = customer2.PhoneNumber,
                PickUpAddress = customer1.Address,
                PickUpTown = customer1.City,
                PickUpCountry = customer1.Country,
                DestinationAddress = "Changed address",
                DestinationTown = customer2.City,
                DestinationCountry = customer2.Country,
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
                },
                null);

            Shipment shipmenNew = await this.GetDbContext().Shipments.Where(x => x.Id == editModel.Id).FirstOrDefaultAsync();

            Assert.Equal("Changed address", shipmenNew.DestinationAddress);
        }

        [Fact]
        public async Task EditShipmentAsyncExceptionTest()
        {
            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111129",
                SenderFirstName = "SFirst",
                SenderLastName = "SLast",
                SenderPhoneNumber = "00359313313131",
                ReceiverFirstName = "RFirst",
                ReceiverLastName = "RLast",
                ReceiverPhoneNumber = "00122112211211",
                PickUpAddress = "Some address",
                PickUpTown = "Some town",
                PickUpCountry = "Some country",
                DestinationAddress = "Another address",
                DestinationTown = "Another town",
                DestinationCountry = "Another country",
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
            };

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            this.GetShipmentService().EditShipmentAsync(shipmentModel, null));
        }

        [Fact]

        public async Task GetShipmentDetailsTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111114",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == "11111111114").FirstOrDefaultAsync();

            ShipmentDetailsViewModel model = await this.GetShipmentService().GetShipmentDetails(shipment.Id);

            Assert.Equal("Gosho Marinov", model.SenderFullName);
            Assert.Equal("Lazur block 33, Bourgas, Bulgaria", model.FullPickUpAddress);
        }

        [Fact]

        public async Task ShipmentExistsTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111115",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == "11111111115").FirstOrDefaultAsync();

            bool result = await this.GetShipmentService().ShipmentExists(shipment.Id);

            Assert.True(result);
        }

        [Fact]

        public async Task EmployeeHasVehicleTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());

            Employee employee = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00359987654314")
                .FirstOrDefaultAsync();

            bool result = await this.GetShipmentService().EmployeeHasVehicle(employee.Id);

            Assert.False(result);
        }

        [Fact]
        public async Task AddEmployeeToShipmentTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());

            Employee employee = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00359987654314")
                .FirstOrDefaultAsync();

            await this.GetShipmentService().AddEmployeeToShipment(1, employee.Id);

            EmployeeShipment employeeShipment = await this.GetDbContext().EmployeesShipments.Where(x => x.EmployeeId == employee.Id && x.ShipmentId == 1).FirstOrDefaultAsync();

            Assert.NotNull(employeeShipment);
        }

        [Fact]

        public async Task AddEmployeeToShipmentExceptionTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111116",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == "11111111116").FirstOrDefaultAsync();

            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetShipmentService().AddEmployeeToShipment(shipment.Id, "61bf43aa-b84d-43c1-ae25-e42c56bce588"));
        }

        [Fact]

        public async Task AddEmployeeToShipmentArgumentExceptionTest()
        {
            await this.GetEmployeeService().CreateEmployeeAsync(this.GetEmployeeFormModel());
            Employee employee = await this.GetDbContext().Employees
                .Where(x => x.PhoneNumber == "00359987654314")
                .FirstOrDefaultAsync();

            await this.GetShipmentService().AddEmployeeToShipment(2, employee.Id);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                this.GetShipmentService().AddEmployeeToShipment(2, employee.Id));
        }

        [Fact]

        public async Task RemoveEmployeeFromShipmentAsyncExceptionTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111117",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == "11111111117").FirstOrDefaultAsync();

            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetShipmentService().RemoveEmployeeFromShipmentAsync(shipment.Id, "bd22feb6-e954-4903-ba40-66fae271a013"));
        }

        [Fact]
        public async Task RemoveEmployeeFromShipmentTest()
        {
            EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

            Employee employee = new Employee()
            {
                FirstName = "Martin",
                MiddleName = "Peshov",
                LastName = "Peshov",
                Address = "Lazur 2",
                City = "Bourgas",
                Country = "Bulgaria",
                HiredOn = DateTime.Now.AddDays(-2),
                PhoneNumber = "00359888888899",
                OfficeId = 1,
                PositionId = 8,
                Salary = 1200,
            };

            await employeeRepo.AddAsync(employee);
            await employeeRepo.SaveChangesAsync();

            EfDeletableEntityRepository<EmployeeShipment> employeeShipmentRepo = new EfDeletableEntityRepository<EmployeeShipment>(this.GetDbContext());

            EmployeeShipment employeeShipment = new EmployeeShipment()
            {
                EmployeeId = employee.Id,
                ShipmentId = 15,
            };

            await employeeShipmentRepo.AddAsync(employeeShipment);

            await employeeShipmentRepo.SaveChangesAsync();

            await this.GetShipmentService().RemoveEmployeeFromShipmentAsync(15, employee.Id);

            Assert.False(await employeeShipmentRepo.All().AnyAsync(x => x.EmployeeId == employee.Id && x.ShipmentId == 15));
        }

        [Fact]
        public async Task DeleteShipmentAsyncTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer2FormModel());

            Customer customer2 = await this.GetDbContext().Customers.Skip(1).FirstOrDefaultAsync();

            ShipmentFormModel shipmentModel = new ShipmentFormModel()
            {
                TrackingNumber = "11111111118",
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
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel, null);

            Shipment shipment = await this.GetDbContext().Shipments
                .Where(x => x.TrackingNumber == "11111111118").FirstOrDefaultAsync();

            await this.GetShipmentService().DeleteShipmentAsync(shipment.Id);

            bool result = await this.GetDbContext().Shipments.AnyAsync(x => x.Id == shipment.Id);

            Assert.False(result);
        }

        [Fact]
        public async Task DeleteShipmentAsyncExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetShipmentService().DeleteShipmentAsync(15));
        }

        [Fact]

        public async Task DeleteShipmentWithVehicleAsyncFromVehicleEmployeeRepo()
        {
            EfDeletableEntityRepository<Shipment> shipmentRepo = new EfDeletableEntityRepository<Shipment>(this.GetDbContext());

            await shipmentRepo.AddAsync(new Shipment()
            {
                TrackingNumber = "11111111117",
                SenderId = "450a5606-d413-4638-9909-b1efefe76be7",
                ReceiverId = "ecd19831-3f30-428b-a154-f6a0408f1214",
                PickupAddress = "Sender address",
                PickUpTown = "Bourgas",
                PickUpCountry = "Bulgaria",
                DestinationAddress = "Receiver address",
                DestinationTown = "Varna",
                DestinationCountry = "Bulgaria",
                Weight = 0.90,
                DeliveryWay = 0,
                DeliveryType = 0,
                ProductType = (ProductType)4,
                Price = 4.90m,
            });

            await shipmentRepo.SaveChangesAsync();

            Shipment shipment = await this.GetDbContext().Shipments.Where(x => x.TrackingNumber == "11111111117").FirstOrDefaultAsync();

            EfDeletableEntityRepository<ShipmentVehicle> shipmentVehicleRepo = new EfDeletableEntityRepository<ShipmentVehicle>(this.GetDbContext());

            await shipmentVehicleRepo.AddAsync(new ShipmentVehicle()
            {
                ShipmentId = shipment.Id,
                VehicleId = 1,
            });

            await shipmentVehicleRepo.SaveChangesAsync();

            await this.GetShipmentService().DeleteShipmentAsync(shipment.Id);

            Assert.False(await shipmentVehicleRepo.All().AnyAsync(x => x.ShipmentId == shipment.Id && x.VehicleId == 1));
        }
    }
}
