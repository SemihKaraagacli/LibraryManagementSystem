using LibraryManagementSystem.Services.Book.ViewModel;

namespace LibraryManagementSystem.Services.Book.Services
{
    public interface IBookService
    {
        ServiceResult<List<BooksViewModel>> GetAll();
        ServiceResult<IQueryable<BooksViewModel>> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publisher);
        ServiceResult<BooksViewModel?> GetById(int id);
        ServiceResult<BooksViewModel> Add(CreateBookViewModel entity);
        ServiceResult Update(BooksViewModel entity);
        ServiceResult Delete(int id);
    }
}
