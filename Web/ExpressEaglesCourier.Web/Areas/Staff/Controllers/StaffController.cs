namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using ExpressEaglesCourier.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;

    [Authorize(Roles = ManagerRoleName + ", " + AdministratorRoleName + ", " + EmployeeRoleName)]
    [Area("Staff")]
    public class StaffController : BaseController
    {
    }
}
