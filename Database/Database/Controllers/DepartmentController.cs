using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly NewDbContext _context;

        public DepartmentController(NewDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var users = _context.Departments.ToList();
            return View(users);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department depart)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(depart);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depart);
        }
    }
}
