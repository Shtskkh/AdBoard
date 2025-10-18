using Microsoft.EntityFrameworkCore;

namespace Adboard.Infrastructure.DataAccess.Repositories.JoinEntitiesRepository;

public class JoinRepository<TJoinEntity, TContext> : IJoinRepository<TJoinEntity, TContext>
    where TJoinEntity : class
    where TContext : DbContext
{
    private readonly TContext _context;
    private readonly DbSet<TJoinEntity> _dbSet;

    public JoinRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<TJoinEntity>();
    }
    
    public IQueryable<TJoinEntity> GetAllAsync()
    {
        return _dbSet;
    }
}