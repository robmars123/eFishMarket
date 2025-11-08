using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetPagedProducts;

namespace EFM.Products.Api.Factories.Abstractions;
public interface IGetPagedProductsFactory
{
    ProductResponse Create(GetPagedProductsResponse source);
    IEnumerable<ProductResponse> Create(IEnumerable<GetPagedProductsResponse> source);
}
