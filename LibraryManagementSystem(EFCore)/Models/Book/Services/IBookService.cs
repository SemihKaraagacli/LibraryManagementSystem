using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Book.ViewModel;

namespace LibraryManagementSystem_EFCore_.Models.Book.Services
{
    public interface IBookService
    {
        IEnumerable<BooksViewModel> GetAll();
        IQueryable<BooksViewModel> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish);
        BooksViewModel? GetById(int id);
        BooksViewModel Add(CreateBookViewModel entity);
        void Update(BooksViewModel entity);
        void Delete(int id);
    }
}
