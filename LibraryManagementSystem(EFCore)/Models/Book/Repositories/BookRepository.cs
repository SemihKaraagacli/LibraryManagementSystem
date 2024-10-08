using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Repositories;

namespace LibraryManagementSystem_EFCore_.Models.Book.Repositories
{
    public class BookRepository(IGenericRepository<Books> _books) : IBookRepository
    {
        public Books Add(Books entity)
        {
            return _books.Add(entity);
        }

        public void Delete(int id)
        {
            _books.Delete(id);
        }

        public IQueryable<Books> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish)
        {
            return _books.Search(search, title, author, publicationYear, isbn, genre, publish);
        }
        public Books? GetById(int id)
        {
            return _books.GetById(id);
        }

        public void Update(Books entity)
        {
            _books.Update(entity);
        }

        public IEnumerable<Books> GetAll()
        {
            return _books.GetAll();
        }
    }
}
