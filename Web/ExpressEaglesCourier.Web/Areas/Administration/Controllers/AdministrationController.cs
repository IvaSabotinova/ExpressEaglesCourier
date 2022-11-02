namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
