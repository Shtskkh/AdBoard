using Adboard.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Интерфейс базового репозитория
/// </summary>
/// <typeparam name="TEntity">Тип сущности репозитория</typeparam>
/// <typeparam name="TKey">Тип первичного ключа сущности</typeparam>
/// <typeparam name="TContext">Контекст базы данных</typeparam>
public interface IRepository<TEntity, TKey, TContext> 
    where TEntity : class, IEntity<TKey> 
    where TContext : DbContext
{
    /// <summary>
    /// Метод для отложенных запросов к таблице сущности
    /// </summary>
    /// <returns>Query</returns>
    IQueryable<TEntity> GetAllAsync();
    
    /// <summary>
    /// Метод получения сущности по её первичному ключу
    /// </summary>
    /// <param name="id">Первичный ключ</param>
    /// <returns>Объект сущности</returns>
    Task<TEntity?> GetByIdAsync(TKey id);
    
    /// <summary>
    /// Метод добавления сущности в БД
    /// </summary>
    /// <param name="entity">Объект сущности</param>
    /// <returns></returns>
    Task AddAsync(TEntity entity);
    
    /// <summary>
    /// Метод обновления сущности в БД
    /// </summary>
    /// <param name="entity">Объект сущности</param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);
    
    /// <summary>
    /// Метод удаления сущности из БД
    /// </summary>
    /// <param name="id">Объект сущности</param>
    /// <returns></returns>
    Task DeleteAsync(TKey id);
}