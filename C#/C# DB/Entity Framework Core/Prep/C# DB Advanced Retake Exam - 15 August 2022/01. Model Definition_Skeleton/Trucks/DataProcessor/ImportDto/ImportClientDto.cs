using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [JsonProperty("Name")]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }
        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; }
        
        public int[] Trucks { get; set; }
    }
}
