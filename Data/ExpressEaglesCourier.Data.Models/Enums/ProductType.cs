namespace ExpressEaglesCourier.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;

    public enum ProductType
    {
        [Display(Name = GlobalConstants.EntitiesConstants.CarParts)]
        CarParts,
        Documents,
        Stationeries,
        Furniture,
        Textile,
        Medicaments,
        Technique,
    }
}
