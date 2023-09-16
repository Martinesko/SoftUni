namespace Library.Data.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
//Has Id – a unique integer, Primary Key
//    • Has Name – a string with min length 5 and max length 50 (required)
//    • Has Books – a collection of type Books