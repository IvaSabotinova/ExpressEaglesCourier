// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Common.Models;
    using ExpressEaglesCourier.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Feedback : BaseDeletableModel<int>
    {
        /// <summary>
        /// Gets or sets the title of customer's or user's feedback, complaints or recommendations.
        /// </summary>
        [Required]
        [MaxLength(FeedbackTitleMaxLength)]
        [Comment("Title of the feedback of a customer or user.")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of customer's or user's feedback, complaints or recommendations.
        /// </summary>
        [Required]
        [MaxLength(FeedbackContentMaxLength)]
        [Comment("Content of the feedback of a customer or user.")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether feedback is positive, negative,
        /// neutral or just recommendation.
        /// </summary>
        [Comment("A value indicating whether feedback is positive, negative, neutral or just recommendation.")]
        public FeedbackType? FeedbackType { get; set; }

        /// <summary>
        /// Gets or sets the shipment that the feedback refers to.
        /// </summary>
        [Comment("The id of the shipment that the feedback refers to.")]
        public int? ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationUser that provided feedback.
        /// </summary>
        [Required]
        [Comment("The id of the ApplicationUser that provided feedback.")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Gets or sets the name under which the customer or user sends his feedback.
        /// </summary>
        [MaxLength(FeedbackSenderNameMaxLength)]
        public string SenderName { get; set; }
    }
}
