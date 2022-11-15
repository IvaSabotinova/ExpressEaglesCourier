namespace ExpressEaglesCourier.Services.Data.Shipments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Shipments;

    public interface IShipmentService
    {
        Task<bool> TrackingNumberExists(string trackingNumber);

        Task<string> GetCustomerId(string firstName, string lastName, string phoneNumber);

        Task<bool> CustomerWithPhoneNumberExists(string firstName, string lastName, string phoneNumber);

        Task CreateShipmentAsync(AddNewShipmentModel addNewShipmentModel);
    }
}
