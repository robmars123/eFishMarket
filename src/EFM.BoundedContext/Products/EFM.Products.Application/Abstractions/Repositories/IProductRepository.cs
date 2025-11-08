using EFM.Products.Application.Products.GetPagedProducts;
using EFM.Products.Application.Products.GetProductById;
using EFM.Products.Domain.Products;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Repositories;
public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken cancellationToken);
    Task<GetProductByIdResponse> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResult<GetPagedProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken);
}
