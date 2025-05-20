namespace EcommerceApp.Cargo.DataAccessLayer.Abstract;

public interface ICargoDetailRepository<T> where T : class, new()
{
    Task CreateAsync(T entity);
    void Delete(T entity);
    Task SaveChangesAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
