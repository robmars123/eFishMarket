namespace EFM.Products.Application.Products.GetPagedProducts;
public class GetPagedProductsResponse
{
    public Guid Id { get; }
    public string Name { get; }

    public decimal UnitPrice { get; }

    public GetPagedProductsResponse(Guid id, string name, decimal unitPrice)
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
    }
}
