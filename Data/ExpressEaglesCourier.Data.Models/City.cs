// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Common.Models;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Offices = new HashSet<Office>();
        }

        [Required]
        [MaxLength(CityNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(CityCodeMaxLength)]
        public string CityCode { get; set; }

        /// <summary>
        /// Gets or sets the country where city is located.
        /// </summary>
        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets collection of offices located in the city.
        /// </summary>
        public virtual ICollection<Office> Offices { get; set; }
    }
}
