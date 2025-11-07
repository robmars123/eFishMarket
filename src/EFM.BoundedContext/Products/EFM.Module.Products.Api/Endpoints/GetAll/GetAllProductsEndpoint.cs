using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Modules.Products.Api.Endpoints.GetAll;

public static class GetAllProductsEndpoint
{
    public static async Task<IResult> GetProducts(
       [AsParameters] ProductRequest request)
    {
        return Results.Ok(request);
    }
}


