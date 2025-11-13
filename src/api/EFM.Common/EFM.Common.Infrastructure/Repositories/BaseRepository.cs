using EFM.Common.Application.Database;
using EFM.Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFM.Common.Infrastructure.Repositories;
public abstract class BaseRepository<T, TDbContext> 
    where T : Entity
    where TDbContext : DbContext
{
    protected readonly TDbContext _dbContext;
    protected readonly string _connection;

    protected BaseRepository(TDbContext dbContext, IConnectionDbFactory connection)
    {
        _dbContext = dbContext;
        _connection = connection.GetConnectionString();
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public virtual void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }
}
