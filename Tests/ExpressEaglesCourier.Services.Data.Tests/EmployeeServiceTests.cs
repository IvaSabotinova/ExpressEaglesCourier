using ExpressEaglesCourier.Data.Models;
using ExpressEaglesCourier.Data.Repositories;
using ExpressEaglesCourier.Data;
using ExpressEaglesCourier.Services.Data.Customers;
using ExpressEaglesCourier.Web.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpressEaglesCourier.Data.Migrations;
using ExpressEaglesCourier.Services.Data.Employees;
using Moq;
using Microsoft.AspNetCore.Identity;

namespace ExpressEaglesCourier.Services.Data.Tests
{
    public class EmployeeServiceTests
    {
        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestEmployee");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
        }

        public EmployeeService GetEmployeeService()
        {
            EfDeletableEntityRepository<Employee> employeeRepo = new EfDeletableEntityRepository<Employee>(this.GetDbContext());

            EfDeletableEntityRepository<Office> officeRepo = new EfDeletableEntityRepository<Office>(this.GetDbContext());

            EfDeletableEntityRepository<Position> positionRepo = new EfDeletableEntityRepository<Position>(this.GetDbContext());

            EfDeletableEntityRepository<Vehicle> vehicleRepo = new EfDeletableEntityRepository<Vehicle>(this.GetDbContext());

            Mock<UserManager<ApplicationUser>> userManagerMock = new Mock<UserManager<ApplicationUser>>();

            UserManager<ApplicationUser> userManager = userManagerMock.Object;

            EmployeeService employeeService = new EmployeeService(employeeRepo, officeRepo, positionRepo, vehicleRepo, userManager);

            return employeeService;
        }

        //public CustomerFormModel GetCustomerFormModel()
        //{
        //    CustomerFormModel model = new CustomerFormModel()
        //    {
        //        Id = "74d8ad86-ef7a-49bf-b435-96f263b0ed2d",
        //        FirstName = "Gosho",
        //        MiddleName = "Goshev",
        //        LastName = "Goshev",
        //        Address = "Lazur block 33",
        //        City = "Bourgas",
        //        Country = "Bulgaria",
        //        CompanyName = string.Empty,
        //        PhoneNumber = "00359889124567",
        //    };

        //    return model;
        //}

        //[Fact]
        //public async Task CheckWhetherNewCustomerIsAdded()
        //{
        //    await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());

        //    Assert.True(this.GetDbContext().Customers.Any(x => x.FirstName == "Gosho"));
        //}

        //[Fact]
        //public async Task GetCustomerByIdTest()
        //{
        //    await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());

        //    Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();
        //    Customer customerService = await this.GetCustomerService().GetCustomerById(customer.Id);

        //    Assert.Equal(customer.Id, customerService.Id);
        //    Assert.Equal(customer.FirstName, customerService.FirstName);
        //}

        //[Fact]

        //public async Task GetCustomerDetailsByIdTest()
        //{
        //    await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());
        //    Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

        //    CustomerDetailsViewModel model = await this.GetCustomerService().GetCustomerDetailsById(customer.Id);

        //    Assert.Equal(customer.Address + ", " + customer.City + ", " + customer.Country, model.FullAddress);
        //    Assert.Equal(customer.FirstName + " " + customer.LastName, model.FullName);
        //}

        //[Fact]

        //public async Task GetCustomerForEditAsyncTest()
        //{
        //    await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());
        //    Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

        //    CustomerFormModel model = await this.GetCustomerService()
        //        .GetCustomerForEditAsync(customer.Id);

        //    Assert.Equal(customer.FirstName, model.FirstName);
        //    Assert.Equal(customer.Country, model.Country);
        //}

        //[Fact]
        //public async Task GetCustomerForEditExceptionTest()
        //{
        //    Customer customer = await this.GetDbContext().Customers.Where(x => x.FirstName == "Martin").FirstOrDefaultAsync();

        //    await Assert.ThrowsAsync<NullReferenceException>(() =>
        //    this.GetCustomerService().GetCustomerForEditAsync(customer.Id));
        //}

        //[Fact]
        //public async Task EditCustomerAsyncTest()
        //{
        //    CustomerFormModel model1 = new CustomerFormModel()
        //    {
        //        Id = "82c5d8b6-2a6d-4756-aeb1-de696291deaf",
        //        FirstName = "Pesho",
        //        MiddleName = "Peshev",
        //        LastName = "Peshev",
        //        Address = "Zornitsa block 15",
        //        City = "Bourgas",
        //        Country = "Bulgaria",
        //        CompanyName = string.Empty,
        //        PhoneNumber = "00359888111111",
        //    };

        //    await this.GetCustomerService().CreateCustomerAsync(model1);

        //    Customer customer = await this.GetDbContext().Customers.LastOrDefaultAsync();

        //    CustomerFormModel model2 = await this.GetCustomerService().GetCustomerForEditAsync(customer.Id);

        //    await this.GetCustomerService().EditCustomerAsync(new CustomerFormModel()
        //    {
        //        Id = model2.Id,
        //        FirstName = model2.FirstName,
        //        MiddleName = model2.MiddleName,
        //        LastName = "Goshev",
        //        Address = model2.Address,
        //        City = model2.City,
        //        Country = model2.Country,
        //        CompanyName = model2.CompanyName,
        //        PhoneNumber = model2.PhoneNumber,
        //    });

        //    Customer customerNew = await this.GetDbContext().Customers.LastOrDefaultAsync();

        //    Assert.Equal("Goshev", customerNew.LastName);
        //}

        //[Fact]

        //public async Task DeleteCustomerAsyncTest()
        //{
        //    CustomerFormModel model = new CustomerFormModel()
        //    {
        //        Id = "82c5d8b6-2a6d-4756-aeb1-de696291deaf",
        //        FirstName = "Pesho",
        //        MiddleName = "Peshev",
        //        LastName = "Peshev",
        //        Address = "Zornitsa block 15",
        //        City = "Bourgas",
        //        Country = "Bulgaria",
        //        CompanyName = string.Empty,
        //        PhoneNumber = "00359888111111",
        //    };

        //    await this.GetCustomerService().CreateCustomerAsync(model);

        //    Customer customer = await this.GetDbContext().Customers.LastOrDefaultAsync();

        //    await this.GetCustomerService().DeleteCustomerAsync(customer.Id);

        //    Assert.False(await this.GetDbContext().Customers
        //        .AnyAsync(x => x.Id == "82c5d8b6-2a6d-4756-aeb1-de696291deaf"));
        //}
    }
}
