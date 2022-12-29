namespace ExpressEaglesCourier.Web.ViewModels.Employees
{
    using System.Collections.Generic;

    using ExpressEaglesCourier.Web.ViewModels.Pagination;

    public class EmployeeListAllViewModel : PagingEmployeeAllViewModel
    {
        public IEnumerable<EmployeeAllViewModel> Employees { get; set; }
    }
}
