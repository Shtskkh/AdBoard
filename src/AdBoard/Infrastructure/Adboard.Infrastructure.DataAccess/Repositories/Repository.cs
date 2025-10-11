using Adboard.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories;

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
    
    /// <summary>
    /// Метод для отложенных запросов к таблице сущности
    /// </summary>
    /// <returns>Query</returns>
    public IQueryable<TEntity> GetAllAsync()
    {
        return _dbSet;
    }

    /// <summary>
    /// Метод получения сущности по её первичному ключу
    /// </summary>
    /// <param name="id">Первичный ключ</param>
    /// <returns>Объект сущности</returns>
    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity ?? null;
    }

    /// <summary>
    /// Метод добавления сущности в БД
    /// </summary>
    /// <param name="entity">Объект сущности</param>
    /// <returns></returns>
    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Метод обновления сущности в БД
    /// </summary>
    /// <param name="entity">Объект сущности</param>
    /// <returns></returns>
    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    /// <summary>
    /// Метод удаления сущности из БД
    /// </summary>
    /// <param name="id">Объект сущности</param>
    /// <returns></returns>
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