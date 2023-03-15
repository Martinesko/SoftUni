﻿using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedOn { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }
        public Album Album { get; set; }

        [ForeignKey("Writer")]
        public int WriterId { get; set; }
        public virtual Writer Writer {get;set;}
        public decimal Price { get; set; }
        
        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
