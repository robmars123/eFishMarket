using EFM.Products.Infrastructure.Database;
using EFM.Products.Domain.Products;

namespace EFM.Products.Infrastructure.Repositories;
public class BaseRepository<T> where T : Entity
{
    protected readonly ProductDbContext DbContext;

    public BaseRepository(ProductDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await DbContext.Set<T>().AddAsync(entity, cancellationToken);
    }

    public virtual void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }
}
