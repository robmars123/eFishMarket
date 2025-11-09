using EFM.Products.Api.Models;
using EFM.Products.Application.Products.AddProduct;
using EFM.Common.Application.Mediator;
using Microsoft.AspNetCore.Http;

namespace EFM.Products.Api.Endpoints.Create;
public class AddProductEndpoint
{
    public static async Task<IResult> CreateProduct(CreateProductRequest product, IDispatcher dispatcher)
    {
        if (product == null)
        {
            return Results.BadRequest();
        }

        var command = new AddProductCommand(product.Name, product.UnitPrice);
        await dispatcher.Send(command);

        return Results.Created($"/api/product", product);
    }
}
