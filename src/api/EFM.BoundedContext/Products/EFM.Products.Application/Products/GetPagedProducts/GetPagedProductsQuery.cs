using EFM.Common.Application.Queries;
using EFM.Common.Application.Results;

namespace EFM.Products.Application.Products.GetPagedProducts;

public record GetPagedProductsQuery(int Page, int PageSize) : IRequest<PagedResponse<GetPagedProductsResponse>>;
