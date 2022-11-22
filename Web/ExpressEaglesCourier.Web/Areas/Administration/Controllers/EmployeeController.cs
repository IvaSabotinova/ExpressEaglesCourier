namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Services.Data.Shipments;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<EmployeeAllViewModel> model = await this.employeeService.GetAllAsync();
            return this.View(model);
        }
    }
}
