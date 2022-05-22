using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project()
        {
            this.Tasks = new HashSet<Task>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(CommonConstants.PROJECT_NAME_MIN_LENGTH)]
        [MaxLength(CommonConstants.PROJECT_NAME_MAX_LENGTH)]
        public string Name { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}