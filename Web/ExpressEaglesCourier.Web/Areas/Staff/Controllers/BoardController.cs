namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BoardController : StaffController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
