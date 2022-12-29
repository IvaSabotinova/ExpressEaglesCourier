namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Web.ViewModels.Employees;

    public interface IEmployeeService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllOfficesDetailsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllPositionsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetVehiclesAsKeyValuePairs();

        Task<string> CreateEmployeeAsync(EmployeeFormModel model);

        Task AddRolesToEmployees(Employee employee);

        Task<EmployeeDetailsViewModel> GetEmployeeDetails(string employeeId);

        Task<Employee> GetEmployeeById(string employeeId);

        Task<EmployeeFormModel> GetEmployeeForEditAsync(string employeeId);

        Task EditEmployeeAsync(EmployeeFormModel model);

        Task DeleteEmployeeAsync(string employeeId);

        Task DeleteEmployeeApplicationUser(Employee employee);

        Task<int> GetEmployeesCountAsync();

        Task<IEnumerable<T>> GetAllAsync<T>(int page, int itemsPerPage);
    }
}
