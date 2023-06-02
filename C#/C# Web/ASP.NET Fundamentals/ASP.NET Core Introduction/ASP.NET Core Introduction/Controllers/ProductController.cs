using ASP.NET_Core_Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ASP.NET_Core_Introduction.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
        {
        new ProductViewModel()
        {
            Id = 1,
            Name = "Cheese",
            Price = 7.00
        } ,
        new ProductViewModel()
        {
            Id = 2,
            Name = "Ham",
            Price = 5.50
        } ,
        new ProductViewModel()
        {
            Id = 3,
            Name = "Bread",
            Price = 1.50
        }
    };
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = _products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
                return View(foundProducts);
            }
            return View(_products);
        }
        public IActionResult ById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
        public IActionResult AllAsJson()
        {
            var opt = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return Json(_products,opt);
        }
        public IActionResult AllAsText()
        {
            var text = string.Empty;
            foreach (var product in _products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price} lv.";
                text += Environment.NewLine;
            }
            return Content(text);
        }
        public IActionResult AllAsTextFile()
        {
            var text = string.Empty;
            foreach (var product in _products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price} lv.";
                text += Environment.NewLine;
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=product.txt");

            return File(Encoding.UTF8.GetBytes(text), "text/plain");
        }
        
    }
}
