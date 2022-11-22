namespace ExpressEaglesCourier.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;

    public enum DeliveryWay
    {
        [Display(Name = GlobalConstants.EntitiesConstants.DoorToDoor)]
        DoorToDoor,
        [Display(Name = GlobalConstants.EntitiesConstants.DoorToOffice)]
        DoorToOffice,
        [Display(Name = GlobalConstants.EntitiesConstants.OfficeToDoor)]
        OfficeToDoor,
        [Display(Name = GlobalConstants.EntitiesConstants.OfficeToOffice)]
        OfficeToOffice,
    }
}
