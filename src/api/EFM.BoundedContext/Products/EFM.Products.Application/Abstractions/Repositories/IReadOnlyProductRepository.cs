using EFM.Products.Application.Products.GetPagedProducts;
using EFM.Products.Application.Products.GetProductById;
using EFM.Common.Application.Results;

namespace EFM.Products.Application.Repositories;
public interface IReadOnlyProductRepository
{
    Task<GetProductByIdResponse> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<PagedResponse<GetPagedProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken);
}
