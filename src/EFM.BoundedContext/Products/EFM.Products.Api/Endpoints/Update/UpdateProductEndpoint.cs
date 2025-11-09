using EFM.Products.Api.Models;
using EFM.Products.Application.Products.UpdateProduct;
using EFM.SharedKernel.Application.Mediator;
using Microsoft.AspNetCore.Http;

namespace EFM.Products.Api.Endpoints.Update;
public class UpdateProductEndpoint
{
    public static async Task<IResult> UpdateProduct(UpdateProductRequest product, IDispatcher dispatcher)
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
