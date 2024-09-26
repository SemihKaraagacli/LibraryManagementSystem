using _1WeekTask.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1WeekTask.Controllers
{
    public class HomeController(IBookService bookService) : Controller // Burada Dependency Injection patternin kurallarý arasýnda olan constructor injection youluyla ayný ama daha kýsa hali olan Primary constructor'ý kullandým. 
    {
        public IActionResult Index()
        {
            var booksList = bookService.GetAllBook();  // bookservis interfaceden üretilen nesneden tüm kitaplarý getiriyor.
            return View(booksList);
        }
        public IActionResult Detail(int id)
        {
           var book = bookService.GetByIdBook(id); // bookservis interfaceden üretilen nesneden id'si istenilen kitap getiriliyor.
            return View(book);

        }
    }
}
