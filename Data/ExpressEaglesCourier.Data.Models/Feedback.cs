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
        /// Gets or sets customer's feedback, complaints or recommendations regarding a particular shipment.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntityConstants.FeedbackLengthMaxLength)]
        [Comment("Content of the feedback of a customer concerning particular shipment.")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether customer's feedback is positive.
        /// </summary>
        public bool IsPositive { get; set; }

        /// <summary>
        /// Gets or sets the shipment that the feedback refers to.
        /// </summary>
        [Required]
        public string ShipmentId { get; set; }

        public virtual Shipment Shipment { get; set; }

        /// <summary>
        /// Gets or sets the customer that provided his/her feedback.
        /// </summary>
        [Required]
        public string CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the office that serviced the customer who has provided his/her feedback.
        /// </summary>
        public string OfficeId { get; set; }

        public virtual Office Office { get; set; }
    }
}
