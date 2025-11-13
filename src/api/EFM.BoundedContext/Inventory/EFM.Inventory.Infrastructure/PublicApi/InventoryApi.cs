using EFM.Common.Application.Mediator;
using EFM.Inventory.Application.InventoryItems.AddInventoryItem;
using EFM.Inventory.PublicApi;

namespace EFM.Inventory.Infrastructure.PublicApi;
public class InventoryApi : IInventoryApi
{
    private readonly IDispatcher _dispatcher;

    public InventoryApi(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    public async Task AddInventoryItem(Guid productId, CancellationToken cancellationToken)
    {
        await _dispatcher.Send(new AddInventoryItemCommand(productId, 0), cancellationToken);

        //publish event or notification if needed
    }
}
