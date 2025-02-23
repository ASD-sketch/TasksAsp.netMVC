using Microsoft.AspNetCore.Mvc;

namespace LibraryOnline.Controllers
{
    public class BookController : Controller
    {
        private static List<string> Books = new List<string>
    {
        "كتاب الأدب العربي",
        "كتاب العلوم الحديثة",
        "كتاب التاريخ الإسلامي"
    };
        public IActionResult Index()
        {
            ViewBag.Books = Books;
            return View();
        }

        public IActionResult AddBook(string bookTitle)
        {
            if (string.IsNullOrEmpty(bookTitle))
            {
                ViewBag.ErrorMessage = "يرجى إدخال عنوان الكتاب.";
            }
            else if (Books.Contains(bookTitle))
            {
                ViewBag.ErrorMessage = "هذا الكتاب موجود بالفعل!";
            }
            else
            {
                Books.Add(bookTitle);
            }
            ViewBag.Books = Books;
            return View("Index");
        }

        public IActionResult DeleteBook(int id)
        {
            if (id >= 0 && id < Books.Count)
            {
                Books.RemoveAt(id);
            }
            return RedirectToAction("Index");
        }

       

    }
}
