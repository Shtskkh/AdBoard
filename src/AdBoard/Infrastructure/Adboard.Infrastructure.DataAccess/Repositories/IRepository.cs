using Adboard.Domain.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories;

public interface IRepository<TEntity, TKey, TContext> 
    where TEntity : class, IEntity<TKey> 
    where TContext : DbContext
{
    IQueryable<TEntity> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TKey id);
}