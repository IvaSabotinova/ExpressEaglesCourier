// ReSharper disable VirtualMemberCallInConstructor
using ExpressEaglesCourier.Common;
using ExpressEaglesCourier.Data.Common.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExpressEaglesCourier.Data.Models
{
    public class Shipment : BaseDeletableModel<string>
    {
        public Shipment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.TrackingNumberMaxLength)]
        public string TrackingNumber { get; set; }
    }
}
