using LibraryManagementSystem.Models.Book.ViewModel;

namespace LibraryManagementSystem.Models.Book.Services
{
    public interface IBookService
    {
        List<BookViewModel> GetAll();

        BookViewModel? GetById(int id);
        BookViewModel Add(CreateBookViewModel books);
        void Update(UpdateBookViewModel books);
        void Delete(int id);
    }
}
