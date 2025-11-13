namespace EFM.Products.Api.Models;
/// <summary>
/// Immutable dto class for updating a product.
/// </summary>
/// <param name="Name"></param>
/// <param name="Price"></param>
public record UpdateProductRequest(Guid Id, string Name, decimal UnitPrice, bool IsDeleted);
