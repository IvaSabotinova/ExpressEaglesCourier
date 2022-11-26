namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ExpressEaglesCourier.Web.ViewModels.Customers;
    using ExpressEaglesCourier.Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllOfficesDetailsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllPositionsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllVehiclesAsKeyValuePairs();

        Task<bool> EmployeeExist(string firstName, string lastName, string phoneNumber);

        Task<string> CreateEmployeeAsync(EmployeeFormModel model);

        Task<EmployeeDetailsViewModel> GetEmployeeDetails(string employeeId);

        Task<IEnumerable<EmployeeAllViewModel>> GetAllAsync(int shipmentId);
    }
}
