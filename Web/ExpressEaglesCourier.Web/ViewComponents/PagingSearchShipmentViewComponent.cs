namespace ExpressEaglesCourier.Web.ViewComponents
{
    using System.Threading.Tasks;

    using ExpressEaglesCourier.Services.Data.Searches;
    using ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment;
    using Microsoft.AspNetCore.Mvc;

    public class PagingSearchShipmentViewComponent : ViewComponent
    {
        private readonly ISearchService searchService;

        public PagingSearchShipmentViewComponent(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productType = null, string searchCustomerName = null, ShipmentSortingCriterion shipmentSortingCriterion = 0, int page = 1)
        {
            ShipmentPagingAndSearchViewModel model = new ShipmentPagingAndSearchViewModel()
            {
               ItemsPerPage = 2,
               CurrentPageNumber = page,
               AllItemsCount = await this.searchService.ShipmentsCountAsyncBySearchCriteria(productType, searchCustomerName, shipmentSortingCriterion),
               ProductType = productType,
               SearchCustomerName = searchCustomerName,
               ShipmentSortingCriterion = shipmentSortingCriterion,
            };

            return this.View(model);
        }
    }
}
