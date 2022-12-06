namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using ExpressEaglesCourier.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static ExpressEaglesCourier.Common.GlobalConstants;

    [Authorize(Roles = AdministratorRoleName + ", " + ManagerRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
