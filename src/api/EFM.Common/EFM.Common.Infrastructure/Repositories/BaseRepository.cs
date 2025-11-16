using EFM.Common.Application.Database;
using EFM.Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFM.Common.Infrastructure.Repositories;

/// <summary>
/// Provides a base implementation for repository patterns, offering common data access operations such as adding and
/// updating entities. This class is designed to work with a specific entity type and database context.
/// </summary>
/// <remarks>This abstract class serves as a foundation for creating repositories that interact with a database
/// using Entity Framework. It provides basic functionality for adding and updating entities, and it ensures that
/// derived repositories have access to the database context and connection string.</remarks>
/// <typeparam name="T">The type of the entity managed by the repository. Must inherit from <see cref="Entity"/>.</typeparam>
/// <typeparam name="TDbContext">The type of the database context used by the repository. Must inherit from <see cref="DbContext"/>.</typeparam>
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
