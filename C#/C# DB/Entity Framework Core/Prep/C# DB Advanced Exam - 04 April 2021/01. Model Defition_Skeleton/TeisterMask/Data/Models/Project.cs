using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        public Project() 
        {
         this.Tasks = new List<Task>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        
        public DateTime? DueDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
    
    }
}
