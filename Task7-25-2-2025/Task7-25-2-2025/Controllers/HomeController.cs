using Microsoft.AspNetCore.Mvc;
using Task7_25_2_2025.Models;

namespace Task7_25_2_2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;

        public HomeController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


        
    }
}
