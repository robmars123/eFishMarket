using EFM.Products.Application.Products.GetAllProducts;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Application.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.GetAll;

public static class GetAllProductsEndpoint
{
    public static async Task<IResult> GetProducts(
       [FromQuery] int page,
       [FromQuery] int pageSize,
       IDispatcher dispatcher,
       CancellationToken cancellationToken)
    {
        // Ensure valid input
        page = page <= 0 ? 1 : page;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        GetPagedProductsQuery query = new GetPagedProductsQuery(page, pageSize);

        PagedResult<GetAllProductsResponse> result = await dispatcher.Send<GetPagedProductsQuery, PagedResult<GetAllProductsResponse>>(query, cancellationToken);
        return Results.Ok(result);
    }
}


