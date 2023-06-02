using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportDespatcherTrucksDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$")]
        public string? RegistrationNumber { get; set; }

        [MinLength(17)]
        [MaxLength(17)]
        [Required]
        [XmlElement("VinNumber")]
        public string VinNumber { get; set; } = null!;


        [Range(950, 1420)]
        [XmlElement("TankCapacity")]
        public int TankCapacity { get; set; }


        [Range(5000, 29000)]
        [XmlElement("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}