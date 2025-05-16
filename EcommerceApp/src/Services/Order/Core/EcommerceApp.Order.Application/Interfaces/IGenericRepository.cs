using System.Linq.Expressions;

namespace EcommerceApp.Order.Application.Interfaces;

public interface IGenericRepository<T> where T : class, new()
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
}
