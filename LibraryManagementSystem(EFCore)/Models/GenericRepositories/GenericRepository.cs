using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Context;
using LibraryManagementSystem_EFCore_.Models.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_EFCore_.Models.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _unitOfWork.Commit();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<T> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                if (typeof(T) == typeof(Books))
                {
                    var books = query as IQueryable<Books>;
                    if (title != false)
                    {
                        query = books.Where(b => b.Title.Contains(search)) as IQueryable<T>;
                    }

                    else if (author != false)
                    {
                        query = books.Where(b => b.Author.Contains(search)) as IQueryable<T>;
                    }

                    else if (publicationYear != false)
                    {
                        query = books.Where(b => b.PublicationYear.ToString().Contains(search)) as IQueryable<T>;
                    }

                    else if (isbn != false)
                    {
                        query = books.Where(b => b.ISBN.Contains(search)) as IQueryable<T>;
                    }

                    else if (genre != false)
                    {
                        query = books.Where(b => b.Genre.Contains(search)) as IQueryable<T>;
                    }

                    else if (publish != false)
                    {
                        query = books.Where(b => b.Publisher.Contains(search)) as IQueryable<T>;
                    }
                }
            }
            return query;
        }
        public T? GetById(int id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> GetAll()
        {
            var value = _dbSet.AsQueryable();
            return value;
        }
    }
}
