namespace EFM.Products.Api.Models;

/// <summary>
/// Represents a request to remove a product identified by its unique identifier.
/// </summary>
/// <param name="Id">The unique identifier of the product to be removed.</param>
public record RemoveProductRequest(Guid Id);
