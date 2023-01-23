namespace ExpressEaglesCourier.Services.Data.Customers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Customers;

    public interface ICustomerService
    {
        Task<string> CreateCustomerAsync(CustomerFormModel createCustomerInputModel);

        Task<T> GetCustomerDetailsById<T>(string id);

        Task<Customer> GetCustomerById(string customerId);

        Task EditCustomerAsync(CustomerFormModel model);

        Task DeleteCustomerAsync(string customerId);

        Task<Customer> FindCustomerByPhoneNumber(string phoneNumber);
    }
}
