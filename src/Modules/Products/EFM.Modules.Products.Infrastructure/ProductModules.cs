using EFM.Modules.Products.Api.Extensions;
using Microsoft.AspNetCore.Routing;

namespace EFM.Modules.Products.Infrastructure;
public static class ProductModules
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapProductEndpoints();
    }
}
