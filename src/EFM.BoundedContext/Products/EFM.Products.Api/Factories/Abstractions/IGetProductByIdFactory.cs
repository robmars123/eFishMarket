using EFM.Products.Api.Models;
using EFM.Products.Application.Products.GetProductById;

namespace EFM.Products.Api.Factories;
public interface IGetProductByIdFactory
{
    ProductResponse Create(GetProductByIdResponse source);
    IEnumerable<ProductResponse> Create(IEnumerable<GetProductByIdResponse> source);
}