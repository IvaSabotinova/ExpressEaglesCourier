namespace ExpressEaglesCourier.Web.ViewComponents
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Employees;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingEmployee;
    using Microsoft.AspNetCore.Mvc;

    public class PagingEmployeeViewComponent : ViewComponent
    {
        private readonly IEmployeeService employeeService;

        public PagingEmployeeViewComponent(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int shipmentId, int page = 1)
        {
            EmployeeWithShipmentPagingViewModel model = new EmployeeWithShipmentPagingViewModel()
            {
                ItemsPerPage = 3,
                CurrentPageNumber = page,
                AllItemsCount = await this.employeeService.GetEmployeesCountAsync(),
                ShipmentId = shipmentId,
            };

            return this.View(model);
        }
    }
}
