﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        public sbyte RowNumber { get; set; }
        [Required]
        [ForeignKey("Play")]
        public int PlayId { get; set; }
        public Play Play { get; set; }
        [Required]
        [ForeignKey("Theatre")]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }

    }
}
