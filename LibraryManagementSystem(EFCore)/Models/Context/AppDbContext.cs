using LibraryManagementSystem_EFCore_.Models.Book.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem_EFCore_.Models.Context
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Books> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
