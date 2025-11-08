using EFM.Products.Api.Factories.Abstractions;
using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetPagedProducts;
using EFM.SharedKernel.Application.Mediator;
using EFM.SharedKernel.Application.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFM.Products.Api.Endpoints.GetAll;

public class GetPagedProductsEndpoint
{
    public static async Task<IResult> GetProducts(
       [FromQuery] int page,
       [FromQuery] int pageSize,
       IDispatcher dispatcher,
       [FromServices] IGetPagedProductsFactory factory,
       CancellationToken cancellationToken)
    {
        // Ensure valid input
        page = page <= 0 ? 1 : page;
        pageSize = pageSize <= 0 ? 10 : pageSize;

        GetPagedProductsQuery query = new GetPagedProductsQuery(page, pageSize);

        PagedResult<GetPagedProductsResponse> result = await dispatcher.Send<GetPagedProductsQuery, PagedResult<GetPagedProductsResponse>>(query, cancellationToken);

        List<ProductResponse> items = factory.Create(result.Items).ToList();

        PagedResponse<ProductResponse> response = new PagedResponse<ProductResponse>(
                        items,
                        result.TotalCount,
                        page,
                        pageSize
                    );
        return Results.Ok(response);
    }
}


