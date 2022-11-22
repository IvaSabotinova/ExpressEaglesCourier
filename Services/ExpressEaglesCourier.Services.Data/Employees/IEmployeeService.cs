namespace ExpressEaglesCourier.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeAllViewModel>> GetAllAsync(int shipmentId);
    }
}
