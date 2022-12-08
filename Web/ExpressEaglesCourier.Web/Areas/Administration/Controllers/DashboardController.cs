namespace ExpressEaglesCourier.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Stats;
    using ExpressEaglesCourier.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IStatsService statsService;

        public DashboardController(IStatsService statsService)
        {
            this.statsService = statsService;
        }

        public async Task<IActionResult> Index()
        {
            DashboardViewModel model = await this.statsService.GetStatsAsync();

            return this.View(model);
        }
    }
}
