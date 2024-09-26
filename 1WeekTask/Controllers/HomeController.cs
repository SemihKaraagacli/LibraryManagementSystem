using _1WeekTask.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace _1WeekTask.Controllers
{
    public class HomeController(IBookService bookService) : Controller // Burada Dependency Injection patternin kurallar� aras�nda olan constructor injection youluyla ayn� ama daha k�sa hali olan Primary constructor'� kulland�m. 
    {
        public IActionResult Index()
        {
            var booksList = bookService.GetAllBook();  // bookservis interfaceden �retilen nesneden t�m kitaplar� getiriyor.
            return View(booksList);
        }
        public IActionResult Detail(int id)
        {
           var book = bookService.GetByIdBook(id); // bookservis interfaceden �retilen nesneden id'si istenilen kitap getiriliyor.
            return View(book);

        }
    }
}
