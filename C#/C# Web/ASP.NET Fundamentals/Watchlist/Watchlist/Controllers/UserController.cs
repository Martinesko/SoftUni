using Microsoft.AspNetCore.Mvc;

namespace Watchlist.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        
    }
}
