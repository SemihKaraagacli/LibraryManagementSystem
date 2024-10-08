using FluentValidation;
using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Book.Services;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_EFCore_.Controllers
{
    public class HomeController(IBookService bookService) : Controller
    {
        public IActionResult Index(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish)
        {
            var books = bookService.Search(search, title, author, publicationYear, isbn, genre, publish);
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var value = bookService.GetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateBookViewModel entity)
        {
            try
            {
                bookService.Add(entity);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.Clear();
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(entity);

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = bookService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(BooksViewModel entity)
        {
            try
            {
                bookService.Update(entity);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.Clear();
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(entity);
        }
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
