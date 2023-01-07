namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingEmployee
{
    using System.Collections.Generic;

    public class EmployeeAllPagingViewModel : EmployeeWithShipmentPagingViewModel
    {
        public IEnumerable<SingleEmployeePagingViewModel> Employees { get; set; } = new List<SingleEmployeePagingViewModel>();
    }
}
