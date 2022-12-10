namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Web.ViewModels.Employee;
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : AdministrationController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult SearchEmployee()
        {
            return this.View();
        }

        public async Task<IActionResult> EmployeeByPhoneNumber([FromQuery] string phoneNumber)
        {
            EmployeeDetailsViewModel model = await this.searchService.SearchEmployeeByPhoneNumberAsync(phoneNumber);

            if (model != null)
            {
                return this.RedirectToAction("Details", "Employee", new { id = model.Id });
            }

            return this.View();
        }
    }
}
