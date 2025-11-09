using EFM.Inventory.Api.Endpoints.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EFM.Inventory.Api.Extensions;
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapInventoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/getInventoryItems", AddInventoryItemEndpoint.AddInventoryItemAsync);
        return endpoints;
    }
}
