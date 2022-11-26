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

        public async Task<string> CreateCustomerAsync(CustomerFormModel model)
        {
            bool isClient = this.customerRepo.AllAsNoTracking().Any(x => x.PhoneNumber == model.PhoneNumber
            && x.FirstName == model.FirstName && x.LastName == model.LastName);

            if (isClient)
            {
                throw new ArgumentException(ClientExists);
            }

            Customer newCustomer = new Customer()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                CompanyName = model.CompanyName,
                PhoneNumber = model.PhoneNumber,
            };

            await this.customerRepo.AddAsync(newCustomer);
            await this.customerRepo.SaveChangesAsync();

            return newCustomer.Id;
        }

        public async Task<CustomerDetailsViewModel> GetCustomerDetailsById(string id)
        {
            Customer customer = await this.customerRepo.AllAsNoTracking()
                .Include(x => x.SentShipments)
                .Include(x => x.ReceivedShipments)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            return new CustomerDetailsViewModel()
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}",
                FullAddress = $"{customer.Address}, {customer.City}, {customer.Country}",
                CompanyName = customer.CompanyName,
                PhoneNumber = customer.PhoneNumber,
                TotalNumberOfShipments = customer.SentShipments.Count() + customer.ReceivedShipments.Count(),
            };
        }

        public async Task<Customer> GetCustomerById(string customerId)
            => await this.customerRepo.All().FirstOrDefaultAsync(x => x.Id == customerId);

        public async Task<CustomerFormModel> GetCustomerForEditAsync(string customerId)
        {
            Customer customer = await this.GetCustomerById(customerId);

            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            CustomerFormModel model = new CustomerFormModel()
            {
                Id = customerId,
                FirstName = customer.FirstName,
                MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                Country = customer.Country,
                CompanyName = customer.CompanyName,
                PhoneNumber = customer.PhoneNumber,
            };
            return model;
        }

        public async Task EditCustomerAsync(CustomerFormModel model)
        {
            Customer customer = await this.GetCustomerById(model.Id);

            bool isClient = this.customerRepo.AllAsNoTracking().Any(x => x.PhoneNumber == model.PhoneNumber
           && x.FirstName == model.FirstName && x.LastName == model.LastName);

            if (isClient)
            {
                throw new ArgumentException(ClientExists);
            }

            customer.Id = model.Id;
            customer.FirstName = model.FirstName;
            customer.MiddleName = model.MiddleName;
            customer.LastName = model.LastName;
            customer.Address = model.Address;
            customer.City = model.City;
            customer.Country = model.Country;
            customer.CompanyName = model.CompanyName;
            customer.PhoneNumber = model.PhoneNumber;

            await this.customerRepo.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(string customerId)
        {
            Customer customer = await this.GetCustomerById(customerId);

            if (customer == null)
            {
                throw new ArgumentException(ClientNotExist);
            }

            this.customerRepo.Delete(customer);
            await this.customerRepo.SaveChangesAsync();
        }
    }
}
