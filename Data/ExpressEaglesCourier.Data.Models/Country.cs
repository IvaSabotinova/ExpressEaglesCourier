// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Common.Models;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Country : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CountryNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(CountryCodeMaxLength)]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets collection of cities with courier offices.
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}
