using AutoMapper;
using FluentValidation;
using LibraryManagementSystem.Models.Book.Services;
using LibraryManagementSystem.Models.Book.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController(IBookService bookService, IMapper mapper) : Controller // Burada Dependency Injection patternin kurallarý arasýnda olan constructor injection youluyla ayný ama daha kýsa hali olan Primary constructor'ý kullandým. 
    {
        public IActionResult Index()
        {
            var booksList = bookService.GetAll();  // bookservis interfaceden üretilen nesneden tüm kitaplarý getiriyor.
            return View(booksList);
        }
        public IActionResult Detail(int id)
        {
            var book = bookService.GetById(id); // bookservis interfaceden üretilen nesneden id'si istenilen kitap getiriliyor.
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
            catch (ValidationException ex) //Eðer Add iþlemi sýrasýnda bir ValidationException (doðrulama hatasý) oluþursa, bu hata burada yakalanýr. ex deðiþkeni, hata ile ilgili bilgilere eriþim saðlar.
            {
                ModelState.Clear();//ModelState.Clear(); çaðrýsý, mevcut model durumundaki tüm hata mesajlarýný temizler. Bu, yeni hata mesajlarýný eklemek için temiz bir durum saðlar.
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); //Her hata için, hata adý (error.PropertyName) ve hata mesajý (error.ErrorMessage) ModelState'e eklenir. Bu, kullanýcýya hatalarýn ne olduðunu gösterir.
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
            catch (ValidationException ex) //Eðer Add iþlemi sýrasýnda bir ValidationException (doðrulama hatasý) oluþursa, bu hata burada yakalanýr. ex deðiþkeni, hata ile ilgili bilgilere eriþim saðlar.
            {
                ModelState.Clear();//ModelState.Clear(); çaðrýsý, mevcut model durumundaki tüm hata mesajlarýný temizler. Bu, yeni hata mesajlarýný eklemek için temiz bir durum saðlar.
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage); //Her hata için, hata adý (error.PropertyName) ve hata mesajý (error.ErrorMessage) ModelState'e eklenir. Bu, kullanýcýya hatalarýn ne olduðunu gösterir.
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
