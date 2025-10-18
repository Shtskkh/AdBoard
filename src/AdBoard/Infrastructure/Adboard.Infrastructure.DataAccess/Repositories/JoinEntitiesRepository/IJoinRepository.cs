using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories.JoinEntitiesRepository;

public interface IJoinRepository<TJoinEntity, TContext>
    where TJoinEntity : class
    where TContext : DbContext
{
    IQueryable<TJoinEntity> GetAllAsync();
}