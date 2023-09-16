using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        
        [Required]
        public int MovieId { get; set; }
        
        [Required]
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}
