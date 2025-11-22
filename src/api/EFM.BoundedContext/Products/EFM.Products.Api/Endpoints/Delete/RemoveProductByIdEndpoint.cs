using EFM.Common.Application.Mediator;
using EFM.Products.Api.Models;
using EFM.Products.Application.Products.RemoveProductById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.Delete;

public class RemoveProductByIdEndpoint
{
    public static async Task<IResult> RemoveProduct([FromBody] RemoveProductRequest product, IDispatcher dispatcher)
    {
        if (product == null)
        {
            return Results.BadRequest();
        }
        var command = new RemoveProductCommand(product.Id);

        //Sync call to Application Layer
        await dispatcher.Send(command);

        return Results.Ok();
    }
}
