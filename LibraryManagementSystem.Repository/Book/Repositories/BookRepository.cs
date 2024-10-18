using LibraryManagementSystem.Repository.Book.Entities;
using LibraryManagementSystem.Repository.Context;
using LibraryManagementSystem.Repository.GenericRepositories;

namespace LibraryManagementSystem.Repository.Book.Repositories
{
    public class BookRepository(IGenericRepository<Books> _books, AppDbContext appDbContext) : IBookRepository
    {
        public Books Add(Books entity)
        {
            return _books.Add(entity);
        }

        public bool Any(Func<Books, bool> func)
        {
            return appDbContext.Books.Any(func);
        }

        public void Delete(int id)
        {
            _books.Delete(id);
        }

        public List<Books> GetAll()
        {
            return _books.GetAll();
        }

        public Books? GetById(int id)
        {
            return _books.GetById(id);
        }
        public void Update(Books entity)
        {
            _books.Update(entity);
        }

        public IQueryable<Books> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publisher)
        {
            var query = appDbContext.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                if (title)
                {
                    query = query.Where(b => b.Title.Contains(search));
                }

                if (author)
                {
                    query = query.Where(b => b.Author.Contains(search));
                }

                if (publicationYear)
                {
                    query = query.Where(b => b.PublicationYear.ToString().Contains(search));
                }

                if (isbn)
                {
                    query = query.Where(b => b.ISBN.Contains(search));
                }

                if (genre)
                {
                    query = query.Where(b => b.Genre.Contains(search));
                }

                if (publisher)
                {
                    query = query.Where(b => b.Publisher.Contains(search));
                }
            }

            return query;
        }
    }

}

