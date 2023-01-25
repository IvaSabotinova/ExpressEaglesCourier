namespace ExpressEaglesCourier.Web.ViewModels.ShipmentTrackingPaths
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;
    using static ExpressEaglesCourier.Common.GlobalConstants.ViewModelConstants;

    public class ShipmentTrackingPathFormModel : IMapFrom<ShipmentTrackingPath>, IMapTo<ShipmentTrackingPath>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }

        [Required]
        [StringLength(TrackingNumberMaxLength, MinimumLength = TrackingNumberMinLength)]
        [Display(Name = GlobalConstants.ViewModelConstants.TrackingNumber)]
        public string TrackingNumber { get; set; }

        [Display(Name = DateTimeAcceptanceFromCustomer)]
        public DateTime? AcceptanceFromCustomer { get; set; }

        [Display(Name = DateTimePickUpByCourier)]
        public DateTime? PickedUpByCourier { get; set; }

        public int? SendingOfficeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Offices_Dispatch { get; set; } = new List<KeyValuePair<string, string>>();

        [Display(Name = DateTimeSentFromOffice)]
        public DateTime? SentFromDispatchingOffice { get; set; }

        public int? ReceivingOfficeId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Offices_Receipt { get; set; } = new List<KeyValuePair<string, string>>();

        [Display(Name = DateTimeArrivalAtOffice)]
        public DateTime? ArrivalInReceivingOffice { get; set; }

        [Display(Name = DateTimePrepForFinalDelivery)]
        public DateTime? FinalDeliveryPreparation { get; set; }

        [Display(Name = DateTimeFinalDelivery)]
        public DateTime? FinalDelivery { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ShipmentTrackingPathFormModel, ShipmentTrackingPath>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
