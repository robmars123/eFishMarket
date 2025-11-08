using EFM.Products.Api.Factories.Abstractions;
using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetPagedProducts;

namespace EFM.Products.Api.Factories;
public class GetPagedProductsFactory : IGetPagedProductsFactory
{
    public ProductResponse Create(GetPagedProductsResponse source)
    {
        if (source == null)
        {
            return null;
        }

        return new ProductResponse(source.Id, source.Name, source.UnitPrice);
    }

    public IEnumerable<ProductResponse> Create(IEnumerable<GetPagedProductsResponse> source)
    {
        if (source == null)
        {
            return Enumerable.Empty<ProductResponse>();
        }

        return source.Select(Create);
    }
}
