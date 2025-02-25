using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    public class AccountController : Controller
    {

         private readonly MyDbContextRegister _context;

        public AccountController(MyDbContextRegister context)
        {
            _context = context;
        }




        public IActionResult Home()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = userName;
            return View();
        }



        public IActionResult Register()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Registers.Add(register);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(register);
        }



        public IActionResult Login()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Registers.FirstOrDefault(record => record.Email == email && record.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                return RedirectToAction("Home");
            }

            ViewBag.Message = "Invalid email or password!";
            return View();
        }






    }
}
