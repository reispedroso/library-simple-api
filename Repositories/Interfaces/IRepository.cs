namespace Ecc.Repositories.Interfaces;
public interface IRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid guid);
    Task<T> Update(Guid guid, T entity);
    Task Delete(Guid guid);
}