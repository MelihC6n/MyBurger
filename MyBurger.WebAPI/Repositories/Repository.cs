using Microsoft.EntityFrameworkCore;
using MyBurger.WebAPI.Context;

namespace MyBurger.WebAPI.Repositories;

public class Repository<T>(ApplicationDbContext context) where T : class
{
    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        context.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(List<T> entity, CancellationToken cancellationToken = default)
    {
        context.RemoveRange(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<T>().FindAsync(id, cancellationToken);
    }
}
