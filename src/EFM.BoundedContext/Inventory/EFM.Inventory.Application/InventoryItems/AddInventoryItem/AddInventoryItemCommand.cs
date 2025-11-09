using EFM.Common.Application.Commands;

namespace EFM.Inventory.Application.InventoryItems.AddInventoryItem;

public class AddInventoryItemCommand : ICommand
{
    public Guid ProductId { get; set; }

    public AddInventoryItemCommand(Guid productId)
    {
        ProductId = productId;
    }
}
