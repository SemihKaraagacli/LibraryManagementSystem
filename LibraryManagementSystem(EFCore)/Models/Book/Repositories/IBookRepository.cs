using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using LibraryManagementSystem_EFCore_.Models.Repositories;

namespace LibraryManagementSystem_EFCore_.Models.Book.Repositories
{
    public interface IBookRepository : IGenericRepository<Books>
    {
    }
}
