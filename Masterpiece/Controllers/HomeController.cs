using System.Diagnostics;
using Masterpiece.Models;
using Microsoft.AspNetCore.Mvc;

namespace Masterpiece.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult ProductDet()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

    }
}
