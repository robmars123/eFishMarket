namespace EFM.Modules.Products.Api.Endpoints.GetAll;

public sealed class ProductRequest
{
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreatedDate { get; private set; }
}


