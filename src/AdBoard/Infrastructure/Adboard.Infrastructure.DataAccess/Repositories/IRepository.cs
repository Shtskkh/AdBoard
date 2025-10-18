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
    /// <returns>Найденная сущность или null, если не найдена</returns>
    Task<TEntity?> GetByIdAsync(TKey id);
    
    /// <summary>
    /// Метод добавления сущности в БД
    /// </summary>
    /// <param name="entity">Сущность</param>
    Task AddAsync(TEntity entity);
    
    /// <summary>
    /// Метод добавления нескольких сущностей в БД
    /// </summary>
    /// <param name="entities">Массив сущностей</param>
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    
    /// <summary>
    /// Метод обновления сущности в БД
    /// </summary>
    /// <param name="entity">Сущность для обновления</param>
    Task UpdateAsync(TEntity entity);
    
    /// <summary>
    /// Метод удаления сущности из БД
    /// </summary>
    /// <param name="id">Id сущности для обновления</param>
    Task DeleteAsync(TKey id);
}