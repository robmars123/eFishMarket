using EFM.Common.Domain.Abstractions;
using EFM.Inventory.Domain.InventoryItems;

namespace EFM.Inventory.Application.Abstractions.Repositories;

public interface IInventoryItemRepository
{
    Task AddInventoryItemAsync(InventoryItem item, CancellationToken cancellationToken);
    Task<InventoryItem?> GetInventoryByIdAsync(Guid id, CancellationToken cancellationToken);
}
