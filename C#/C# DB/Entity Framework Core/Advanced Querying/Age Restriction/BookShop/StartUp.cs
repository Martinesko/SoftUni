namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine(RemoveBooks(context));
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
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var output = context.Authors.Where(a => a.FirstName.EndsWith(input)).OrderBy(a => a.FirstName).ThenBy(a=>a.LastName).Select(a => $"{a.FirstName} {a.LastName}").ToList();
        return string.Join(Environment.NewLine, output);
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var output = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower())).OrderBy(b=>b.Title).Select(b => b.Title).ToList();

            return string.Join(Environment.NewLine, output);
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var output = context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower())).OrderBy(b => b.BookId).Select(b=>$"{b.Title} ({b.Author.FirstName} {b.Author.LastName})").ToList();

            return string.Join(Environment.NewLine, output);
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var output = context.Books.Where(b => b.Title.Length>lengthCheck).Count();

            return output;
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var output = context.Authors.OrderByDescending(a=> a.Books.Sum(b => b.Copies)).Select(a => $"{a.FirstName} {a.LastName} - {a.Books.Sum(b => b.Copies)}");

            return string.Join(Environment.NewLine, output);
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var output = context.Categories.OrderByDescending(c=> c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)).Select(c => $"{c.Name} ${c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies):f2}").ToList();

            return string.Join( Environment.NewLine, output);
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var list = context.Categories.OrderBy(c => c.Name).Select(c => new
            {
                Category = c.Name,
                Books = c.CategoryBooks.OrderByDescending(p => p.Book.ReleaseDate).Take(3).Select(b => $"{b.Book.Title} ({b.Book.ReleaseDate.Value.Year})").ToList()
            }).ToList();
            StringBuilder output = new StringBuilder();
            
            foreach (var item in list)
            {
                output.AppendLine($"--{item.Category}");
                output.AppendLine(string.Join(Environment.NewLine, item.Books));
            }
            return output.ToString().Trim();
        }
        public static void IncreasePrices(BookShopContext context)
        {

            foreach (var book in context.Books.Where(b => b.ReleaseDate.Value.Year<2010))
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            int counter = 0;
            foreach (var book in context.Books.Where(b => b.Copies<4200))
            {
                counter++;
                context.Books.Remove(book);
                
            }
            context.SaveChanges();
            return counter;
        }

    }
}


