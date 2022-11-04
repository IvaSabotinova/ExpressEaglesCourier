// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Offices = new HashSet<Office>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.OfficeCityNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.EntitiesConstants.CityCodeMaxLength)]
        public string CityCode { get; set; }

        /// <summary>
        /// Gets or sets the country where city is located.
        /// </summary>
        [Required]
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets collection of offices located in the city.
        /// </summary>
        public virtual ICollection<Office> Offices { get; set; }
    }
}
