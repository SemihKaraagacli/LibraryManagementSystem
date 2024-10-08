using LibraryManagementSystem_EFCore_.Models.Context;

namespace LibraryManagementSystem_EFCore_.Models.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
