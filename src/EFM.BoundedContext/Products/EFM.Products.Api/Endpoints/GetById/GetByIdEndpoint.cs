using EFM.Products.Application.Products.GetPagedProducts;
using EFM.Products.Application.Products.GetProductById;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Application.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.GetById;

public static class GetByIdEndpoint
{
    public static async Task<IResult> GetProductById(
       [FromQuery] Guid id,
       IDispatcher dispatcher,
       CancellationToken cancellationToken)
    {
        GetProductByIdQuery query = new GetProductByIdQuery(id);

        GetProductByIdResponse result = await dispatcher.Send<GetProductByIdQuery, GetProductByIdResponse>(query, cancellationToken);
        return Results.Ok(result);
    }
}
