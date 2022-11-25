namespace ExpressEaglesCourier.Services.Data.Customers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Customers;

    public interface ICustomerService
    {
        Task<string> CreateCustomerAsync(CustomerFormModel createCustomerInputModel);

        Task<CustomerDetailsViewModel> GetCustomerDetailsById(string id);

        Task<CustomerFormModel> GetCustomerForEditAsync(string customerId);

        Task<Customer> GetCustomerById(string customerId);

        Task EditCustomerAsync(CustomerFormModel model);

        Task DeleteCustomerAsync(string customerId);
    }
}
