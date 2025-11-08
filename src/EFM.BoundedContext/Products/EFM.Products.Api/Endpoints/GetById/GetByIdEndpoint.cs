using EFM.Products.Application.Products.GetAllProducts;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Application.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.GetById;

public static class GetByIdEndpoint
{
    //public static async Task<IResult> GetProductById(
    //   [FromQuery] Guid id,
    //   IDispatcher dispatcher,
    //   CancellationToken cancellationToken)
    //{
    //    GetPagedProductsQuery query = new GetPagedProductsQuery(page, pageSize);

    //    PagedResult<GetAllProductsResponse> result = await dispatcher.Send<GetPagedProductsQuery, PagedResult<GetAllProductsResponse>>(query, cancellationToken);
    //    return Results.Ok(result);
    //}
}
