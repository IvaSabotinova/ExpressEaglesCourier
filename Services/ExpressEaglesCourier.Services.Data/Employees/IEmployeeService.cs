namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllOfficesDetailsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllPositionsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetVehiclesAsKeyValuePairs();

        Task<bool> EmployeeExist(string firstName, string lastName, string phoneNumber);

        Task<string> CreateEmployeeAsync(EmployeeFormModel model);

        Task<EmployeeDetailsViewModel> GetEmployeeDetails(string employeeId);

        Task<Employee> GetEmployeeById(string employeeId);

        Task<EmployeeFormModel> GetEmployeeForEditAsync(string employeeId);

        Task EditEmployeeAsync(EmployeeFormModel model);

        Task<IEnumerable<EmployeeAllViewModel>> GetAllAsync(int shipmentId);
    }
}
