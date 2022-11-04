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
        [MaxLength(GlobalConstants.EntitiesConstants.CountryNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.CountryCodeMaxLength)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets collection of cities with courier offices.
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}
