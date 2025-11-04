using Microsoft.AspNetCore.Http;

namespace EFM.Modules.Products.Api.Endpoints.GetAll;

public static class GetAllProductsEndpoint
{
    public static async Task<IResult> GetProducts(
        ProductRequest request)
    {
        return Results.Ok(request);
    }
}


