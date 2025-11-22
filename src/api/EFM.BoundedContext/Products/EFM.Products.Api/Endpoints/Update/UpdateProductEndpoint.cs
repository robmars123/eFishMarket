using EFM.Common.Application.Mediator;
using EFM.Products.Api.Models;
using EFM.Products.Application.Products.UpdateProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.Update;
public class UpdateProductEndpoint
{
    public static async Task<IResult> UpdateProduct([FromBody] UpdateProductRequest product, IDispatcher dispatcher)
    {
        if (product == null)
        {
            return Results.BadRequest();
        }
        var command = new UpdateProductCommand(product.Id, product.Name, product.UnitPrice, product.IsDeleted);
        await dispatcher.Send(command);
        return Results.Ok();
    }
}
