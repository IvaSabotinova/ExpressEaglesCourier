namespace ExpressEaglesCourier.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;

    public enum DeliveryType
    {
        [Display(Name = GlobalConstants.EntitiesConstants.SameDayCourier)]
        SamedayCourier,
        [Display(Name = GlobalConstants.EntitiesConstants.OvernightShipping)]
        OvernightShipping,
        [Display(Name = GlobalConstants.EntitiesConstants.StandardDeliveryService)]
        StandardDeliveryService,
    }
}
