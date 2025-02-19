using Microsoft.AspNetCore.Mvc;

namespace Task3_Login__Register.Controllers
{
    public class UserController : Controller
    {



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            HttpContext.Session.SetString("UserName", username);
            HttpContext.Session.SetString("Password", password);
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            String userName =  HttpContext.Session.GetString("UserName");
            String PassWord = HttpContext.Session.GetString("Password");


            if (username == userName && password == PassWord) // مثال على تحقق بسيط
            {
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction("Home", "Home");
            }
            ViewBag.Error = "اسم المستخدم أو كلمة المرور غير صحيحة";
            return View();
        }


        public IActionResult Profile() 
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
            
           
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }





    }
}
