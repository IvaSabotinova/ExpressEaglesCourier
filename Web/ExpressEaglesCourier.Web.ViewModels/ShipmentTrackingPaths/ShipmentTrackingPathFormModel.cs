namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public class ShipmentTrackingPathFormModel
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }

        [Required]
        [StringLength(TrackingNumberMaxLength, MinimumLength = TrackingNumberMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.TrackingNumber)]
        public string TrackingNumber { get; set; }

        [Display(Name = DateTimePickUp)]
        public DateTime? PickedUpByCourier { get; set; }

        [Display(Name = DateTimeSentFromOffice)]
        public DateTime? SentFromDispatchingOffice { get; set; }

        [Display(Name = DateTimeArrivalAtOffice)]
        public DateTime? ArrivalInReceivingOffice { get; set; }

        [Display(Name = DateTimePrepForFinalDelivery)]
        public DateTime? FinalDeliveryPreparation { get; set; }

        [Display(Name = DateTimeFinalDelivery)]
        public DateTime? FinalDelivery { get; set; }
    }
}
