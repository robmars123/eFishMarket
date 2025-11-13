using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetProductById;

namespace EFM.Products.Api.Factories;
public class GetProductByIdFactory : IGetProductByIdFactory
{
    public ProductResponse Create(GetProductByIdResponse source)
    {
        if (source == null)
        {
            return null;
        }

        return new ProductResponse(source.Id, source.Name, source.UnitPrice);
    }

    public IEnumerable<ProductResponse> Create(IEnumerable<GetProductByIdResponse> source)
    {
        if (source == null)
        {
            return Enumerable.Empty<ProductResponse>();
        }

        return source.Select(Create);
    }
}
