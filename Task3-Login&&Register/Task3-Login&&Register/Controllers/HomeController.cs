using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task3_Login__Register.Models;

namespace Task3_Login__Register.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
           
        
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }

       
    }
}
