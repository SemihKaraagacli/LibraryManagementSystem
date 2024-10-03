using AutoMapper;
using FluentValidation;
using LibraryManagementSystem.Models.Book.Services;
using LibraryManagementSystem.Models.Book.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController(IBookService bookService, IMapper mapper) : Controller // Burada Dependency Injection patternin kurallar� aras�nda olan constructor injection youluyla ayn� ama daha k�sa hali olan Primary constructor'� kulland�m. 
    {
        public IActionResult Index()
        {
            var booksList = bookService.GetAll();  // bookservis interfaceden �retilen nesneden t�m kitaplar� getiriyor.
            return View(booksList);
        }
        public IActionResult Detail(int id)
        {
            var book = bookService.GetById(id); // bookservis interfaceden �retilen nesneden id'si istenilen kitap getiriliyor.
            return View(book);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBookViewModel books)
        {
            try
            {
                bookService.Add(books);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex) //E�er Add i�lemi s�ras�nda bir ValidationException (do�rulama hatas�) olu�ursa, bu hata burada yakalan�r. ex de�i�keni, hata ile ilgili bilgilere eri�im sa�lar.
            {
                ModelState.Clear();//ModelState.Clear(); �a�r�s�, mevcut model durumundaki t�m hata mesajlar�n� temizler. Bu, yeni hata mesajlar�n� eklemek i�in temiz bir durum sa�lar.
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); //Her hata i�in, hata ad� (error.PropertyName) ve hata mesaj� (error.ErrorMessage) ModelState'e eklenir. Bu, kullan�c�ya hatalar�n ne oldu�unu g�sterir.
                }
                return View(books);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = bookService.GetById(id);
            var bookstoId = mapper.Map<UpdateBookViewModel>(book);
            return View(bookstoId);
        }
        [HttpPost]
        public IActionResult Update(UpdateBookViewModel books)
        {
            try
            {
                bookService.Update(books);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex) //E�er Add i�lemi s�ras�nda bir ValidationException (do�rulama hatas�) olu�ursa, bu hata burada yakalan�r. ex de�i�keni, hata ile ilgili bilgilere eri�im sa�lar.
            {
                ModelState.Clear();//ModelState.Clear(); �a�r�s�, mevcut model durumundaki t�m hata mesajlar�n� temizler. Bu, yeni hata mesajlar�n� eklemek i�in temiz bir durum sa�lar.
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); //Her hata i�in, hata ad� (error.PropertyName) ve hata mesaj� (error.ErrorMessage) ModelState'e eklenir. Bu, kullan�c�ya hatalar�n ne oldu�unu g�sterir.
                }
                return View(books);
            }

        }

        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
