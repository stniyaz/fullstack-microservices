using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EcommerceApp.Order.Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    private readonly OrderContext _orderContext;

    public GenericRepository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }
    public async Task CreateAsync(T entity)
    {
        await _orderContext.Set<T>().AddAsync(entity);
        await _orderContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _orderContext.Set<T>().Remove(entity);
        await _orderContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
        => await _orderContext.Set<T>().ToListAsync();

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        => await _orderContext.Set<T>().SingleOrDefaultAsync(filter);

    public async Task<T> GetByIdAsync(int id)
        => await _orderContext.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
        _orderContext.Set<T>().Update(entity);
        await _orderContext.SaveChangesAsync();
    }
}
