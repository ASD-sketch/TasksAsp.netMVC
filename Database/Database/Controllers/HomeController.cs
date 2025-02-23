using System.Diagnostics;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Database.Controllers
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
            var users = _context.Users.ToList();
            return View(users);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }



     



    }
}
