using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [JsonProperty("Username")]
        [RegularExpression(@"^[A-Za-z0-9]{3,}$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("Phone")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public ICollection<int> Tasks { get; set; }
    }
}
