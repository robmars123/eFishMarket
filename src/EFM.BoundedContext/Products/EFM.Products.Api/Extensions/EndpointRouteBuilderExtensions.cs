using EFM.Products.Api.Endpoints.GetAll;
using EFM.Products.Api.Endpoints.GetById;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EFM.Products.Api.Extensions;
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/getPagedProducts", GetPagedProductsEndpoint.GetProducts);
        endpoints.MapGet("/api/getProductById", GetByIdEndpoint.GetProductById);

        return endpoints;
    }
}
