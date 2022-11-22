namespace ExpressEaglesCourier.Services.Data.Customers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;

    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.ServicesConstants;

    public class CustomerService : ICustomerService
    {
        private readonly IDeletableEntityRepository<Customer> customerRepo;

        public CustomerService(IDeletableEntityRepository<Customer> customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public async Task CreateCustomerAsync(AddNewCustomerModel customerInputModel)
        {
            bool isClient = this.customerRepo.AllAsNoTracking().Any(x => x.PhoneNumber == customerInputModel.PhoneNumber
            && x.FirstName == customerInputModel.FirstName && x.LastName == customerInputModel.LastName);

            if (isClient)
            {
                throw new ArgumentException(ClientExists);
            }

            Customer newCustomer = new Customer()
            {
                FirstName = customerInputModel.FirstName,
                MiddleName = customerInputModel.MiddleName,
                LastName = customerInputModel.LastName,
                Address = customerInputModel.Address,
                City = customerInputModel.City,
                Country = customerInputModel.Country,
                CompanyName = customerInputModel.CompanyName,
                PhoneNumber = customerInputModel.PhoneNumber,
            };

            await this.customerRepo.AddAsync(newCustomer);
            await this.customerRepo.SaveChangesAsync();
        }

        public async Task<EditCustomerModel> GetCustomerForEditAsync(string id)
        {
            Customer customer = await this.customerRepo.All().FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            return new EditCustomerModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                CompanyName = customer.CompanyName,
                PhoneNumber = customer.PhoneNumber,
            };
        }

        public async Task EditCustomerAsync(EditCustomerModel editCustomerModel)
        {
            Customer customer = await this.customerRepo.All().FirstOrDefaultAsync(x => x.Id == editCustomerModel.Id);

            customer.Id = editCustomerModel.Id;
            customer.FirstName = editCustomerModel.FirstName;
            customer.MiddleName = editCustomerModel.MiddleName;
            customer.LastName = editCustomerModel.LastName;
            customer.Address = editCustomerModel.Address;
            customer.City = editCustomerModel.City;
            customer.Country = editCustomerModel.Country;
            customer.CompanyName = editCustomerModel.CompanyName;
            customer.PhoneNumber = editCustomerModel.PhoneNumber;

            await this.customerRepo.SaveChangesAsync();
        }
    }
}
