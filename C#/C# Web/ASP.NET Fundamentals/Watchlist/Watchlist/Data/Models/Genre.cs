namespace Watchlist.Data.Models
{
    public class Genre
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 5 and max length 50 (required)
//    •	Has Movies – a collection of Movie
