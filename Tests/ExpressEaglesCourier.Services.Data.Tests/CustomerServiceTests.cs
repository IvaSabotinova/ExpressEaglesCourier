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
                Id = "74d8ad86-ef7a-49bf-b435-96f263b0ed2d",
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
            Customer customer = await this.GetDbContext().Customers.Where(x => x.FirstName == "Martin").FirstOrDefaultAsync();

            await Assert.ThrowsAsync<NullReferenceException>(() =>
            this.GetCustomerService().GetCustomerForEditAsync(customer.Id));
        }

        [Fact]
        public async Task EditCustomerAsyncTest()
        {
            CustomerFormModel model1 = new CustomerFormModel()
            {
                Id = "82c5d8b6-2a6d-4756-aeb1-de696291deaf",
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

        public async Task DeleteCustomerAsyncTest()
        {
            CustomerFormModel model = new CustomerFormModel()
            {
                Id = "82c5d8b6-2a6d-4756-aeb1-de696291deaf",
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
                .AnyAsync(x => x.Id == "82c5d8b6-2a6d-4756-aeb1-de696291deaf"));
        }
    }
}
