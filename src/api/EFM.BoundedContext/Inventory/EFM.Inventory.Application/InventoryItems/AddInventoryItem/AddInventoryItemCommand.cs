using EFM.Common.Application.Commands;

namespace EFM.Inventory.Application.InventoryItems.AddInventoryItem;

public class AddInventoryItemCommand : ICommand
{

    public Guid ProductId { get; set; }
    public int Quantity { get; }

    public AddInventoryItemCommand(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}
