// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class Feedback : BaseModel<string>
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the content of customer's feedback, complaints or recommendations regarding a particular shipment.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.FeedbackLengthMaxLength)]
        [Comment("Content of the feedback of a customer concerning particular shipment.")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customer's feedback is positive.
        /// </summary>
        [Comment("A value indicating whether customer's feedback is positive.")]
        public bool IsPositive { get; set; }

        /// <summary>
        /// Gets or sets the shipment that the feedback refers to.
        /// </summary>
        [Comment("The id of the shipment that the feedback refers to.")]
        [Required]
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the customer that provided his/her feedback.
        /// </summary>
        [Comment("The id of the customer that provided his/her feedback.")]
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
