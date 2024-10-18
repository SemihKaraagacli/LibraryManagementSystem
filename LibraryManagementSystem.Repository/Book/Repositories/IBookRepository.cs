using LibraryManagementSystem.Repository.Book.Entities;
using LibraryManagementSystem.Repository.Context;
using LibraryManagementSystem.Repository.GenericRepositories;

namespace LibraryManagementSystem.Repository.Book.Repositories
{
    public interface IBookRepository : IGenericRepository<Books>
    {
        IQueryable<Books> Search(string search, bool title, bool author, bool publicationYear, bool isbn, bool genre, bool publisher); //Dynamic  Search  Metod
        public bool Any(Func<Books, bool> func); //Service Result Metod
    }
}
