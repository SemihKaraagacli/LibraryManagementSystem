using LibraryManagementSystem_EFCore_.Models.Book.Entities;

namespace LibraryManagementSystem_EFCore_.Models.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publish);
        T? GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}