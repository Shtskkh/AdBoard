using Adboard.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories.EntitiesRepositories;

/// <summary>
/// Реализация базового репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности</typeparam>
/// <typeparam name="TKey">Тип первичного ключа сущности</typeparam>
/// <typeparam name="TContext">Контекст базы данных</typeparam>
public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey, TContext>
    where TEntity : class, IEntity<TKey>
    where TContext : DbContext
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    private readonly TContext _context;
    
    /// <summary>
    /// Таблица базы данных сущности
    /// </summary>
    private readonly DbSet<TEntity> _dbSet;

    public Repository(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    /// <inheritdoc/>
    public IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet;
    }
    
    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity ?? null;
    }

    /// <inheritdoc/>
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    /// <inheritdoc/>
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