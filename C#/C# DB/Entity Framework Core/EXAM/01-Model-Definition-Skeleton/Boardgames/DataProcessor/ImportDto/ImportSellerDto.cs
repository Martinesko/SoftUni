﻿using Boardgames.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [JsonProperty("Address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Required]
        [JsonProperty("Website")]
        [RegularExpression(@"^www.[a-zA-Z0-9-]+.com$")]
        public string Website { get; set; }

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }
    }
}
