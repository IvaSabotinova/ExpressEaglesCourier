namespace ExpressEaglesCourier.Web.Areas.Employee.Controllers
{
    using ExpressEaglesCourier.Web.ViewModels.EmployeeBoard;
    using Microsoft.AspNetCore.Mvc;

    public class BoardController : StaffController
    {
        public IActionResult Index()
        {
            var model = new StaffBoardViewModel()
            {
                NumberOfShipment = 0,
            };

            return this.View(model);
        }
    }
}
