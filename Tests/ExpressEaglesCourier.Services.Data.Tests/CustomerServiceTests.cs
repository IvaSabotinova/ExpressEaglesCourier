namespace ExpressEaglesCourier.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Data.Repositories;
    using ExpressEaglesCourier.Services.Data.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class CustomerServiceTests
    {
        public ApplicationDbContext GetDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestCustomer");
            ApplicationDbContext dbContext = new ApplicationDbContext(optionBuilder.Options);
            return dbContext;
        }

        public CustomerService GetCustomerService()
        {
            EfDeletableEntityRepository<Customer> customerRepo = new EfDeletableEntityRepository<Customer>(this.GetDbContext());

            CustomerService customerService = new CustomerService(customerRepo);
            return customerService;
        }

        public CustomerFormModel GetCustomerFormModel()
        {
            CustomerFormModel model = new CustomerFormModel()
            {
                FirstName = "Gosho",
                MiddleName = "Goshev",
                LastName = "Goshev",
                Address = "Lazur block 33",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359889124567",
            };

            return model;
        }

        [Fact]
        public async Task CheckWhetherNewCustomerIsAdded()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());

            Assert.True(this.GetDbContext().Customers.Any(x => x.FirstName == "Gosho"));
        }

        [Fact]
        public async Task GetCustomerByIdTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());

            Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            Customer customerService = await this.GetCustomerService().GetCustomerById(customer.Id);

            Assert.Equal(customer.Id, customerService.Id);
            Assert.Equal(customer.FirstName, customerService.FirstName);
        }

        [Fact]

        public async Task GetCustomerDetailsByIdExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() =>
                this.GetCustomerService().GetCustomerDetailsById("a6759ca2-fecc-41ee-ba8b-d39235584594"));
        }

        [Fact]

        public async Task GetCustomerDetailsByIdTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());
            Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            CustomerDetailsViewModel model = await this.GetCustomerService().GetCustomerDetailsById(customer.Id);

            Assert.Equal(customer.Address + ", " + customer.City + ", " + customer.Country, model.FullAddress);
            Assert.Equal(customer.FirstName + " " + customer.LastName, model.FullName);
        }

        [Fact]

        public async Task GetCustomerForEditAsyncTest()
        {
            await this.GetCustomerService().CreateCustomerAsync(this.GetCustomerFormModel());
            Customer customer = await this.GetDbContext().Customers.FirstOrDefaultAsync();

            CustomerFormModel model = await this.GetCustomerService()
                  .GetCustomerForEditAsync(customer.Id);

            Assert.Equal(customer.FirstName, model.FirstName);
            Assert.Equal(customer.Country, model.Country);
        }

        [Fact]
        public async Task GetCustomerForEditExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() =>
                  this.GetCustomerService().GetCustomerForEditAsync("c987fb53-c533-468c-80c0-21fc1862ab76"));
        }

        [Fact]
        public async Task EditCustomerAsyncTest()
        {
            CustomerFormModel model1 = new CustomerFormModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359888111111",
            };

            await this.GetCustomerService().CreateCustomerAsync(model1);

            Customer customer = await this.GetDbContext().Customers.LastOrDefaultAsync();

            CustomerFormModel model2 = await this.GetCustomerService().GetCustomerForEditAsync(customer.Id);

            await this.GetCustomerService().EditCustomerAsync(new CustomerFormModel()
            {
                Id = model2.Id,
                FirstName = model2.FirstName,
                MiddleName = model2.MiddleName,
                LastName = "Goshev",
                Address = model2.Address,
                City = model2.City,
                Country = model2.Country,
                CompanyName = model2.CompanyName,
                PhoneNumber = model2.PhoneNumber,
            });

            Customer customerNew = await this.GetDbContext().Customers.LastOrDefaultAsync();

            Assert.Equal("Goshev", customerNew.LastName);
        }

        [Fact]

        public async Task EditCustomerAsyncExceptionTest()
        {
            CustomerFormModel inputModel = new CustomerFormModel()
            {
                FirstName = "Proben",
                MiddleName = "Probov",
                LastName = "Probov",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "000000000001",
            };
            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetCustomerService().EditCustomerAsync(inputModel));
        }

        [Fact]

        public async Task DeleteCustomerAsyncTest()
        {
            CustomerFormModel model = new CustomerFormModel()
            {
                FirstName = "Pesho",
                MiddleName = "Peshev",
                LastName = "Peshev",
                Address = "Zornitsa block 15",
                City = "Bourgas",
                Country = "Bulgaria",
                CompanyName = string.Empty,
                PhoneNumber = "00359888111111",
            };

            await this.GetCustomerService().CreateCustomerAsync(model);

            Customer customer = await this.GetDbContext().Customers.LastOrDefaultAsync();

            await this.GetCustomerService().DeleteCustomerAsync(customer.Id);

            Assert.False(await this.GetDbContext().Customers
                .AnyAsync(x => x.Id == customer.Id));
        }

        [Fact]

        public async Task DeleteCustomerAsyncExceptionTest()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => this.GetCustomerService().DeleteCustomerAsync("61c175da-1a86-4cd1-aa1f-e3807bb41f53"));
        }
    }
}
