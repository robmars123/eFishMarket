namespace EFM.Inventory.Api.Models;
/// <summary>
/// Immutable dto class for adding a inventory item.
/// </summary>
/// <param name="Name"></param>
/// <param name="Price"></param>
public record AddInventoryItemRequest(Guid productId);
