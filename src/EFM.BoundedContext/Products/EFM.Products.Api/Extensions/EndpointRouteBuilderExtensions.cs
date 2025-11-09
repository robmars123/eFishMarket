using EFM.Products.Api.Endpoints.Create;
using EFM.Products.Api.Endpoints.GetAll;
using EFM.Products.Api.Endpoints.GetById;
using EFM.Products.Api.Endpoints.Update;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace EFM.Products.Api.Extensions;
public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/getPagedProducts", GetPagedProductsEndpoint.GetProducts);
        endpoints.MapGet("/api/getProductById", GetByIdEndpoint.GetProductById);
        endpoints.MapPost("/api/createProduct", AddProductEndpoint.CreateProduct);
        endpoints.MapPut("/api/updateProduct", UpdateProductEndpoint.UpdateProduct);
        return endpoints;
    }
}
