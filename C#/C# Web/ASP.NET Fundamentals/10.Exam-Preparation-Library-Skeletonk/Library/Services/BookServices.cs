using Library.Contracts;
using Library.Data;
using Library.Data.Model;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookServices : IBookServices
    {
        private readonly LibraryDbContext dbContext;


        public BookServices(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId)
        {
            return await dbContext.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                  .Select(ub => new MineBookViewModel
                  {
                      Id = ub.BookId,
                      Title = ub.Book.Title,
                      Author = ub.Book.Author,
                      ImageUrl = ub.Book.ImageUrl,
                      Description = ub.Book.Description,
                      Category = ub.Book.Category.Name
                  }).ToListAsync();
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Rating = decimal.Parse(model.Rating),
                CategoryId = model.CategoryId
            };
            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AddBookViewModel> GetAddedBook()
        {
            var categories = await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            return new AddBookViewModel
            {
                Categories = categories
            };
        }

        public async Task AddBookToUserAsync(int id, string userId)
        {
            await dbContext.IdentityUserBooks.AddAsync(new IdentityUserBook
            {
                BookId = id,
                CollectorId = userId
            });
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveBookFromUserAsync(int id, string userId)
        {
            dbContext.IdentityUserBooks.Remove(new IdentityUserBook
            {
                BookId = id,
                CollectorId = userId
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
