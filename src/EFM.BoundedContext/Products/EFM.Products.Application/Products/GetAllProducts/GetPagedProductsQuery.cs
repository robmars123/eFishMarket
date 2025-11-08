using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Products.GetAllProducts;

public record GetPagedProductsQuery(int Page, int PageSize) : IRequest<PagedResult<GetPagedProductsResponse>>;
