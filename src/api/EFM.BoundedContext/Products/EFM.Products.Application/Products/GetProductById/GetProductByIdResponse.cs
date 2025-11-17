using EFM.Common.Application.Results;

namespace EFM.Products.Application.Products.GetProductById;
public class GetProductByIdResponse: Result
{
    public Guid Id { get; }
    public string Name { get; }

    public decimal UnitPrice { get; }

    public GetProductByIdResponse(bool isSuccess, Error error, Guid id, string name, decimal price)
        : base(isSuccess, error)
    {
        Id = id;
        Name = name;
        UnitPrice = price;
    }

    public static GetProductByIdResponse Success(Guid id, string name, decimal price) =>
        new GetProductByIdResponse(true, Error.None, id, name, price);

    public static GetProductByIdResponse Failure(Error error) =>
        new GetProductByIdResponse(false, error, Guid.Empty, string.Empty, 0);
}
