using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    

    public class BookController : BaseController
    {
        private readonly IBookServices services;

        public BookController(IBookServices services)
        {
            this.services = services;
        }

        public async Task<IActionResult> All()
        {
            var model = await services.GetAllBooksAsync();
            return View(model);
        }
        public async   Task<IActionResult> Mine()
        {
            var model = await services.GetMineBooksAsync(GetUserId());
            return View(model);
        }
        public async Task<IActionResult> AddToCollection(int id)
        {
            await services.AddBookToUserAsync(id, GetUserId());
            return RedirectToAction("All");
        }
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            await services.RemoveBookFromUserAsync(id, GetUserId());
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await services.GetAddedBook();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await services.AddBookAsync(model);
            return RedirectToAction("All");
        }
    }
}
