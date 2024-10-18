using LibraryManagementSystem.Repository.Context;

namespace LibraryManagementSystem.Repository.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
