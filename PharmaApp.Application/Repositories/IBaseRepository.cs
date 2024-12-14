
using System.Linq.Expressions;
namespace PharmaApp.Application.Repositories;


public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);

}