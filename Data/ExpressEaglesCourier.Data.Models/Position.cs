// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Common;
    using ExpressEaglesCourier.Data.Common.Models;

    public class Position : BaseDeletableModel<string>
    {
        public Position()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<Employee>();
        }

        [Required]
        [MaxLength(GlobalConstants.EntityConstants.JobTitleMaxLength)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets collection of employees working in the office.
        /// </summary>
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
