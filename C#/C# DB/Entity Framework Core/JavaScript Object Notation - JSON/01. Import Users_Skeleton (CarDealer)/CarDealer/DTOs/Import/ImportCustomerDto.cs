﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.DTOs.Import
{
    public class ImportCustomerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty("isYoungDriver")]
        public bool IsYongerDriver { get; set; }
    }
}