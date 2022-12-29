namespace ExpressEaglesCourier.Web.ViewComponent
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Stats;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponent;
    using Microsoft.AspNetCore.Mvc;

    public class StaffBoardViewComponent : ViewComponent
    {
        private readonly IStatsService statsService;

        public StaffBoardViewComponent(IStatsService statsService)
        {
            this.statsService = statsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            StaffBoardViewModel model = new StaffBoardViewModel()
            {
                 CustomersCount = await this.statsService.CustomersCountAsync(),
                 ShipmentsCount = await this.statsService.ShipmentsCountAsync(),
                 ShipmentTrackingPathsCount = await this.statsService.ShipmentsTrackingPathsCountAsync(),
                 ShipmentProductTypeViewModel = await this.statsService.GetProductTypeStats(),
            };

            return this.View(model);
        }
    }
}
