using EFM.Products.Application.Abstractions.Database;
using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Products.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EFM.Products.Infrastructure.Repositories;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductDbContext dbContext, IConnectionDbFactory connection)
        : base(dbContext, connection)
    {
    }

    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await AddAsync(product, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);
    }
}
