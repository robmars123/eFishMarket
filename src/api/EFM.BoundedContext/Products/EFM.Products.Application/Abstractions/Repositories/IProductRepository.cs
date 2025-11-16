using EFM.Products.Domain.Products;

namespace EFM.Products.Application.Repositories;
public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken cancellationToken);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
