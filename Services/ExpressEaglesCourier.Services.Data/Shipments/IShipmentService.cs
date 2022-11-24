namespace ExpressEaglesCourier.Services.Data.Shipments
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Shipments;

    public interface IShipmentService
    {
        Task<bool> TrackingNumberExists(string trackingNumber);

        Task<string> GetCustomerId(string firstName, string lastName, string phoneNumber);

        Task<bool> CustomerWithPhoneNumberExists(string firstName, string lastName, string phoneNumber);

        Task<int> CreateShipmentAsync(ShipmentFormModel addNewShipmentModel);

        Task<bool> ShipmentExists(int id);

        Task<ShipmentDetailsViewModel> GetShipmentDetails(int id);

        Task<ShipmentFormModel> GetShipmentForEditAsync(int shipmentId);

        Task EditShipmentAsync(ShipmentFormModel model);

        Task AddEmployeeToShipment(int shipmentId, string employeeId);

        Task RemoveEmployeeFromShipmentAsync(int shipmentId, string employeeId);

        Task DeleteShipmentAsync(int shipmentId);
    }
}
