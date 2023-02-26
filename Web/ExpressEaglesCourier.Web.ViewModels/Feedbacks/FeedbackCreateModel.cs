namespace ExpressEaglesCourier.Web.ViewModels.Feedbacks
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Models;
    using ExpressEaglesCourier.Services.Mapping;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class FeedbackCreateModel
    {
        [Required]
        [StringLength(FeedbackTitleMaxLength, MinimumLength = FeedbackTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(FeedbackContentMaxLength, MinimumLength = FeedbackContentMinLength)]
        public string Content { get; set; }

        public string ShipmentTrackingNumber { get; set; } = null;

        [StringLength(FeedbackSenderNameMaxLength)]
        public string SenderName { get; set; } = null;
    }
}
