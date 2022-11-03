// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;

    public class Country : BaseDeletableModel<string>
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.CountryNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.EntityConstants.CountryCodeMaxLength)]
        public string CountryCode { get; set; }

        public virtual ICollection<Office> Offices { get; set; }
    }
}
