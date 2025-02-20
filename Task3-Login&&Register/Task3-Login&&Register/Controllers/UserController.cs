using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

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

            //HttpContext.Session.SetString("UserName", username);
            //HttpContext.Session.SetString("Password", password);
            CookieOptions cook = new CookieOptions();
            cook.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("UserName", username, cook);
            Response.Cookies.Append("Password", password, cook);
            return RedirectToAction("Login");
        }



        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(string username, string password)
        {

            //HttpContext.Session.SetString("UserName", username);
            //HttpContext.Session.SetString("Password", password);
            CookieOptions cook = new CookieOptions();
            cook.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("UserName", username, cook);
            Response.Cookies.Append("Password", password, cook);

            HttpContext.Session.SetString("UserName", username);
            HttpContext.Session.SetString("Password", password);

            return RedirectToAction("Profile");
        }






        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string remember)
        {
            //HttpContext.Session.SetString("UserName", username);
            //HttpContext.Session.SetString("Password", password);
            //String userName = HttpContext.Session.GetString("UserName");
            //String PassWord = HttpContext.Session.GetString("Password");


            if (username == "admin" && password == "1234") 
            {
                HttpContext.Session.SetString("UserName", username);
                HttpContext.Session.SetString("Password", password);
                return RedirectToAction("AdminHome", "Admin");
            }



            string userNamCookies = Request.Cookies["UserName"];
            string PassWordCookies = Request.Cookies["Password"];

            if (username == userNamCookies && password == PassWordCookies) 
            {
                if (remember == null)
                {
                    HttpContext.Session.SetString("UserName", username);
                    HttpContext.Session.SetString("Password", password);
                    return RedirectToAction("Home", "Home");
                }
                if (remember != null) 
                {
                    CookieOptions cook = new CookieOptions();
                    cook.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("UserName", username, cook);
                    Response.Cookies.Append("Password", password, cook);
                    return RedirectToAction("Home", "Home");
                }
            }

            if(username== userNamCookies && password== PassWordCookies)
            {
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction("Home", "Home");
            }

            ViewBag.Error = "Username or Password not correct";
            return View();
        }


        public IActionResult Profile()
        {
            String userName = HttpContext.Session.GetString("UserName");
            String PassWord = HttpContext.Session.GetString("Password");

            if (userName!=null && PassWord !=null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("UserName");
                ViewBag.Password = HttpContext.Session.GetString("Password");
            }

            string userNamCookies = Request.Cookies["UserName"];
            string PassWordCookies = Request.Cookies["Password"];

            if (userNamCookies !=null && PassWordCookies !=null)
            {
                ViewBag.UserName1 = Request.Cookies["UserName"];
                ViewBag.Password1 = Request.Cookies["Password"];
            }

           
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }





    }
}
