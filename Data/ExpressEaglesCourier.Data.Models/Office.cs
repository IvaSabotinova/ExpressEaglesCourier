﻿// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public class Office : BaseDeletableModel<int>
    {
        public Office()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.AddressMaxLength)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the office.
        /// </summary>
        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.PhoneNumberMaxLenght)]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number of the office.
        /// </summary>
        [MaxLength(GlobalConstants.EntitiesConstants.FaxNumberMaxLenght)]
        [Phone]
        public string FaxNumber { get; set; }

        [Required]
        [MaxLength(GlobalConstants.EntitiesConstants.EmailMaxLenght)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        /// <summary>
        /// Gets or sets collection of employees attending the office.
        /// </summary>
        [Comment("Collection of employees attending the office.")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
