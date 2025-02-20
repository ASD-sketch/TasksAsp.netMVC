using Microsoft.AspNetCore.Mvc;

namespace Task3_Login__Register.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminHome()
        {
           
            return View();
        }


        public IActionResult Profile()
        {
            String userName = HttpContext.Session.GetString("UserName");
            String PassWord = HttpContext.Session.GetString("Password");

            if (userName != null && PassWord != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.Password = HttpContext.Session.GetString("Password");
            }

            return View();
        }


    }
}
