namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            //using var db = new BookShopContext();
            

            var context = new BookShopContext();
            DbInitializer.ResetDatabase(context);
            Console.WriteLine(GetBooksReleasedBefore(context,Console.ReadLine()));
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var output = context.Books.Where(b => b.AgeRestriction==ageRestriction).OrderBy(b=>b.Title).Select(b=>b.Title).ToList();
            return (string.Join(Environment.NewLine,output)); 
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var output = context.Books.Where(b=>b.Copies<5000 && b.EditionType==EditionType.Gold).OrderBy(b=>b.BookId).Select(b=>b.Title).ToList();
            return (string.Join(Environment.NewLine, output));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price>40).OrderByDescending(b => b.Price);
            var output = new StringBuilder();
            foreach (var book in books)
            {
                output.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return output.ToString().Trim();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var output = context.Books.Where(b => b.ReleaseDate.Value.Year!=year).OrderBy(b => b.BookId).Select(b => b.Title);
            return string.Join(Environment.NewLine, output);
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputCategories = input.Split(" ").Select(c=>c.ToLower()).ToList();
            var output = context.Books.Where(b=>b.BookCategories.Any(c=> inputCategories.Contains(c.Category.Name.ToLower()))).OrderBy(b=>b.Title).Select(b=>b.Title).ToList();

            return string.Join(Environment.NewLine, output);
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime input = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var output = context.Books.Where(b => b.ReleaseDate<input).OrderByDescending(b=>b.ReleaseDate).Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}");

            

            return string.Join(Environment.NewLine,output);
        }

    }
}


