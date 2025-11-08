using EFM.SharedKernel.Application.Queries;
using EFM.SharedKernel.Application.Results;

namespace EFM.Products.Application.Products.GetPagedProducts;

public record GetPagedProductsQuery(int Page, int PageSize) : IRequest<PagedResult<GetPagedProductsResponse>>;
