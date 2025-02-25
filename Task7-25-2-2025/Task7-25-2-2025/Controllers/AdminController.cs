using Microsoft.AspNetCore.Mvc;
using Task7_25_2_2025.Models;

namespace Task7_25_2_2025.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _context;

        public AdminController(MyDbContext context)
        {
            _context = context;
        }


        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin") return RedirectToAction("Login", "Account");

            var users = _context.Users.ToList();
            var products = _context.Products.ToList();

            ViewBag.Products = products;

            return View(users);
        }


        public IActionResult Users()
        {
           
            var users = _context.Users.ToList();
            return View(users);
        }

       
        public IActionResult DeleteUser(int id)
        {
            

            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

       
     
      
        public IActionResult AddProduct()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
           

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(product);
        }

      
        public IActionResult EditProduct(int id)
        {
          

            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(product);
        }

      
        public IActionResult DeleteProduct(int id)
        {
           

            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }



        public IActionResult EditUser(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin") return RedirectToAction("Login", "Account");

            var user = _context.Users.Find(id);
            if (user == null) return NotFound();

            return View(user);
        }


        [HttpPost]
        public IActionResult EditUser(User updatedUser)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin") return RedirectToAction("Login", "Account");

            var existingUser = _context.Users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser == null) return NotFound();

            if (ModelState.IsValid)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Role = updatedUser.Role; 

              
                if (!string.IsNullOrEmpty(updatedUser.Password))
                {
                    existingUser.Password = updatedUser.Password;
                }

                _context.Users.Update(existingUser);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }
            return View(updatedUser);
        }





    }
}
