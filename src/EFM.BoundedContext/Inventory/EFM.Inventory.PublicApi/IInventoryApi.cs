namespace EFM.Inventory.PublicApi;

public interface IInventoryApi
{
    Task AddInventoryItem(Guid productId, CancellationToken cancellationToken);
}
