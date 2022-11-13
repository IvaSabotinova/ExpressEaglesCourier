namespace ExpressEaglesCourier.Services.Data.Customers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Customers;

    public interface ICustomerService
    {
        Task CreateCustomerAsync(AddNewCustomerModel createCustomerInputModel);

        Task<EditCustomerModel> GetCustomerForEditAsync(string id);

        Task EditCustomerAsync(EditCustomerModel editCustomerModel);
    }
}
