using Microsoft.AspNetCore.Mvc;
using Task7_25_2_2025.Models;

namespace Task7_25_2_2025.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
           
            
                user.Role = "User";
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            
          
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);

                return user.Role == "Admin" ? RedirectToAction("Dashboard", "Admin") : RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid email or password!";
            return View();
        }


        public IActionResult Profile()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (userName == null) return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(u => u.Name == userName);
            return View(user);
        }

        public IActionResult EditProfile()
        {
            var userEmail = HttpContext.Session.GetString("UserName");
            if (userEmail==null) return RedirectToAction("Login", "Account");

            var user = _context.Users.FirstOrDefault(u => u.Name == userEmail);
            if (user == null) return NotFound();

            return View("EditProfile",user);
        }


        [HttpPost]
        public IActionResult EditProfile(User updatedUser)
        {
            var userEmail = HttpContext.Session.GetString("UserName");
            if (userEmail == null) return RedirectToAction("Login", "Account");

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser == null) return NotFound();

                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                _context.Users.Update(existingUser);
                _context.SaveChanges();

                HttpContext.Session.SetString("UserName", existingUser.Name);

                return RedirectToAction("Profile", "Account");
            
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
