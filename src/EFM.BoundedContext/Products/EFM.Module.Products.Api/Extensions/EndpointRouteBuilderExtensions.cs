using EFM.Modules.Products.Api.Endpoints.GetAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EFM.Modules.Products.Api.Extensions;
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/getPagedProducts", GetAllProductsEndpoint.GetProducts);
        // Map GET with query parameters instead of body
        //endpoints.MapGet("/api/getProducts", async (string? filter) =>
        //{
        //    var request = new ProductRequest { };
        //    return Results.Ok(request);
        //});

        return endpoints;
    }
}
