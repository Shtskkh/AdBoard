using Adboard.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories;

public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet;
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity ?? null;
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}