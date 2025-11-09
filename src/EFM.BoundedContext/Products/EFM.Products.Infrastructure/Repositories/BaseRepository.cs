using EFM.Common.Application.Database;
using EFM.Products.Domain.Products;
using EFM.Products.Infrastructure.Database;

namespace EFM.Products.Infrastructure.Repositories;
public abstract class BaseRepository<T> where T : Entity
{
    protected readonly ProductDbContext _dbContext;
    protected readonly string _connection;

    protected BaseRepository(ProductDbContext dbContext, IConnectionDbFactory connection)
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
