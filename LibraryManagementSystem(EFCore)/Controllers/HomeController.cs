using FluentValidation;
using LibraryManagementSystem.Services.Book.Services;
using LibraryManagementSystem.Services.Book.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem_EFCore_.Controllers
{
    public class HomeController(IBookService bookService) : Controller
    {
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult BookList(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publisher)
        {
            //query incoming data in db
            var books = bookService.Search(search, title, author, publicationYear, isbn, genre, publisher);
            var booksToList = books.Data!.ToList();
            return View(booksToList);
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var value = bookService.GetById(id);
            if (value.AnyError)
            {
                TempData["error"] = value.Errors!.First();
                return RedirectToAction("Index");
            }
            return View(value.Data);
        }



        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(CreateBookViewModel entity)
        {
            try
            {
                var result = bookService.Add(entity);
                if (result.AnyError)
                {
                    TempData["error"] = result.GetFirstError;
                    return View();
                }
                return RedirectToAction("BookList");
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



        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            var value = bookService.GetById(id);
            if (value.AnyError)
            {
                TempData["error"] = value.Errors!.First();
                return RedirectToAction("Index");
            }
            return View(value.Data);
        }


        [HttpPost]
        public IActionResult Update(BooksViewModel entity)
        {
            try
            {
                var result = bookService.Update(entity);
                if (result.AnyError)
                {
                    TempData["error"] = result.Errors!.First();
                    return View();
                }
                return RedirectToAction("BookList");
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


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var value = bookService.Delete(id);
            if (value.AnyError)
            {
                TempData["Error"] = value.Errors!.First();
                return RedirectToAction("Index");
            }
            return RedirectToAction("BookList");
        }



        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
