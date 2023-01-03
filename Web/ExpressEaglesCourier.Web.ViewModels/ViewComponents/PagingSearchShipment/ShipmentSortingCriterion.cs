namespace ExpressEaglesCourier.Web.ViewModels.ViewComponents.PagingSearchShipment
{
    using System.ComponentModel.DataAnnotations;

    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public enum ShipmentSortingCriterion
    {
        Newest = 1,
        [Display(Name = OrderByHighestPrice)]
        HighestPrice = 2,
    }
}
