using Microsoft.AspNetCore.Identity;

namespace Watchlist.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<UserMovie> UserMovies { get; set; } = new List<UserMovie>();
    }
}
