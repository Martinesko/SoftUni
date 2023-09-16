using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Contracts
{
    public interface IBookServices
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<IEnumerable<MineBookViewModel>> GetMineBooksAsync(string userId);
        Task AddBookAsync(AddBookViewModel model);
        Task<AddBookViewModel> GetAddedBook();
        Task AddBookToUserAsync(int id, string userId);
        Task RemoveBookFromUserAsync(int id, string userId);
    }
}
