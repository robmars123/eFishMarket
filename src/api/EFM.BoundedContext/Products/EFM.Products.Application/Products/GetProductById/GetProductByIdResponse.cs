using EFM.Common.Application.Results;

namespace EFM.Products.Application.Products.GetProductById;
public class GetProductByIdResponse: Result
{
    public Guid Id { get; }
    public string Name { get; }

    public decimal UnitPrice { get; }

    public GetProductByIdResponse(bool isSuccess, string? error, Guid id, string name, decimal price)
        : base(isSuccess, error)
    {
        Id = id;
        Name = name;
        UnitPrice = price;
    }

    public static GetProductByIdResponse Success(Guid id, string name, decimal price) =>
        new GetProductByIdResponse(true, null, id, name, price);

    public static GetProductByIdResponse Failure(string error) =>
        new GetProductByIdResponse(false, error, Guid.Empty, string.Empty, 0);
}
