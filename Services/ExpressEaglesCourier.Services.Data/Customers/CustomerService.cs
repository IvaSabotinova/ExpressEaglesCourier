namespace ExpressEaglesCourier.Services.Data.Customers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Common.Repositories;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;
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
            Customer newCustomer = AutoMapperConfig.MapperInstance.Map<Customer>(model);

            await this.customerRepo.AddAsync(newCustomer);
            await this.customerRepo.SaveChangesAsync();

            return newCustomer.Id;
        }

        public async Task<T> GetCustomerDetailsById<T>(string id)
        => await this.customerRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();

        public async Task<Customer> GetCustomerById(string customerId)
            => await this.customerRepo.All()
            .FirstOrDefaultAsync(x => x.Id == customerId);

        public async Task EditCustomerAsync(CustomerFormModel model)
        {
            Customer customer = await this.GetCustomerById(model.Id);

            if (customer == null)
            {
                throw new NullReferenceException(ClientNotExist);
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
                throw new NullReferenceException(ClientNotExist);
            }

            this.customerRepo.Delete(customer);
            await this.customerRepo.SaveChangesAsync();
        }

        public async Task<Customer> FindCustomerByPhoneNumber(string phoneNumber)
        {
            Customer customer = null;
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                phoneNumber = phoneNumber.Replace(" ", string.Empty);
                if (phoneNumber.Length == 9)
                {
                    customer = await this.customerRepo.All()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber);
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] == '0')
                {
                    customer = await this.customerRepo.All()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 9) == phoneNumber.Substring(phoneNumber.Length - 9));
                }
                else if (phoneNumber.Length >= 10 && phoneNumber[^10] != '0')
                {
                    customer = await this.customerRepo.All()
                   .FirstOrDefaultAsync(x => x.PhoneNumber.Substring(x.PhoneNumber.Length - 10) == phoneNumber.Substring(phoneNumber.Length - 10));
                }
            }

            return customer;
        }
    }
}
