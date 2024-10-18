namespace LibraryManagementSystem.Repository.GenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);

    }
}