﻿namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Shipments;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class ShipmentServiceTests
    {
        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestShipment");
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

            ShipmentService shipmentService = new ShipmentService(shipmentRepo, customerRepo, employeeRepo, employeeShipmentRepo, shipmentVehicleRepo, vehicleRepo, shipmentTrackingPathRepo);
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
                Id = "908f7741-6e6e-4c23-86ae-0eb81107e880",
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
                Id = "d2f41660-79e8-45a4-852d-3cd99e6935a4",
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

        [Fact]

        public async Task CustomerWithPhoneNumberExistsTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomer1FormModel());

            Customer customer1 = await this.GetDbContext().Customers.FirstOrDefaultAsync();
            await this.GetShipmentService().CustomerWithPhoneNumberExists(customer1.FirstName, customer1.LastName, customer1.PhoneNumber);

            Assert.True(await this.GetShipmentService().CustomerWithPhoneNumberExists(customer1.FirstName, customer1.LastName, customer1.PhoneNumber));
        }

        [Fact]

        public async Task CustomerWithPhoneNumberExistsExceptionTest()
        {
            CustomerFormModel exceptionModel = new CustomerFormModel()
            {
                Id = "f8fe1582-6283-459a-88e1-f89cc0b1e368",
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
                Id = 1,
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
                ProductType = 0,
                Price = 4.90m,
            };
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

            Shipment shipment = await this.GetDbContext().Shipments
                .LastOrDefaultAsync();

            bool result = await this.GetShipmentService().TrackingNumberExists(shipmentModel.TrackingNumber);

            string customer1Id = await this.GetShipmentService().GetCustomerId(customer1.FirstName, customer1.LastName, customer1.PhoneNumber);

            Assert.Equal(shipmentModel.TrackingNumber, shipment.TrackingNumber);
            Assert.True(result);
            Assert.Equal(customer1.Id, customer1Id);
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
                Id = 2,
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
                ProductType = 0,
                Price = 4.90m,
            };
            await this.GetShipmentService().CreateShipmentAsync(model);

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
                Id = 3,
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
                ProductType = 0,
                Price = 4.90m,
            };
            await this.GetShipmentService().CreateShipmentAsync(shipmentModel);

            Shipment shipment = await this.GetDbContext().Shipments.Where(x => x.TrackingNumber == "11111111113").FirstOrDefaultAsync();

            ShipmentFormModel editModel = await this.GetShipmentService()
                .GetShipmentForEditAsync(shipment.Id);

            await this.GetShipmentService().EditShipmentAsync(new ShipmentFormModel()
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
                ProductType = 0,
                Price = 4.90m,
            });

            Shipment shipmenNew = await this.GetDbContext().Shipments.Where(x => x.Id == editModel.Id).FirstOrDefaultAsync();

            Assert.Equal("Changed address", shipmenNew.DestinationAddress);
        }
    }
}