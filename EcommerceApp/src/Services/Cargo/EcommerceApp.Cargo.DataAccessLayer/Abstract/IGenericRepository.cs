using System.Linq.Expressions;

namespace EcommerceApp.Cargo.DataAccessLayer.Abstract;

public interface IGenericRepository<T> where T : class, new()
{
    void Delete(T entity);
    Task SaveChangesAsync();
    Task CreateAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetWhereAsync(Expression<Func<T, bool>> expression);
}
