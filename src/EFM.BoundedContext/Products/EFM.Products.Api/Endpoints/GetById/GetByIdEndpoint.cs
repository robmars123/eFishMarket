using EFM.Products.Api.Factories;
using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetProductById;
using EFM.SharedKernel.Application.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.GetById;

public static class GetByIdEndpoint
{
    public static async Task<IResult> GetProductById(
       [FromQuery] Guid id,
       IDispatcher dispatcher,
       [FromServices] IGetProductByIdFactory factory,
       CancellationToken cancellationToken)
    {
        GetProductByIdQuery query = new GetProductByIdQuery(id);

        GetProductByIdResponse result = await dispatcher.Send<GetProductByIdQuery, GetProductByIdResponse>(query, cancellationToken);

        //Always return DTO objects from API layer
        ProductResponse response = factory.Create(result);

        return Results.Ok(response);
    }
}
