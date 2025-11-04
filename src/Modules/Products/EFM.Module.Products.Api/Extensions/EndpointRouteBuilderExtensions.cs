using EFM.Modules.Products.Api.Endpoints.GetAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EFM.Modules.Products.Api.Extensions;
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/getProducts", GetAllProductsEndpoint.GetProducts);

        return endpoints;
    }
}
