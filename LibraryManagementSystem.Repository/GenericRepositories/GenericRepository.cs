using LibraryManagementSystem.Repository.Book.Entities;
using LibraryManagementSystem.Repository.Context;
using LibraryManagementSystem.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository.GenericRepositories
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

        public List<T> GetAll()
        {
            var value = _dbSet.ToList();
            return value;
        }
    }
}
