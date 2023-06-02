using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class BoardgameSeller
    {
        [Key]
        [ForeignKey("Boardgame")]
        public int BoardgameId { get; set; }
        public Boardgame Boardgame { get; set; }
        [Key]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
