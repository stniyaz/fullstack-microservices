using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceApp.Cargo.DataAccessLayer.Repositories;

public class GenericRepository<T>(CargoContext _context) : IGenericRepository<T> where T : class, new()
{
    public async Task CreateAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public void Delete(T entity)
        => _context.Remove(entity);

    public async Task<List<T>> GetAllAsync()
        => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<T> GetWhereAsync(Expression<Func<T, bool>> expression)
        => await _context.Set<T>().Where(expression).FirstOrDefaultAsync();

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
