using EFM.Products.Application.Products.GetAllProducts;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Repositories;
public interface IProductRepository
{
    Task<PagedResult<GetPagedProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken);
}
