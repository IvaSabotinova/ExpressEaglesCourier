// ReSharper disable VirtualMemberCallInConstructor
namespace ExpressEaglesCourier.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExpressEaglesCourier.Data.Common.Models;
    using Microsoft.EntityFrameworkCore;

    using static ExpressEaglesCourier.Common.GlobalConstants.EntitiesConstants;

    public class Position : BaseDeletableModel<int>
    {
        public Position()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Required]
        [MaxLength(JobTitleMaxLength)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets collection of employees working on that position.
        /// </summary>
        [Comment("Collection of employees working on that position.")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
