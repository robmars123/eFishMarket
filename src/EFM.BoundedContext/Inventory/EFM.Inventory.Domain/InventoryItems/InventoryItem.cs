using EFM.Common.Domain;

namespace EFM.Inventory.Domain.InventoryItems;
public class InventoryItem : Entity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime LastUpdatedUtc { get; private set; }

    public static InventoryItem Create(Guid productId, int quantity, DateTime createdDate)
    {
        if (productId == Guid.Empty)
        {
            throw new ArgumentException("Product Id name cannot be empty.", nameof(productId));
        }

        if (quantity < 0)
        {
            throw new ArgumentException("Quantity must be greater than or equal to zero.", nameof(quantity));
        }

        var id = Guid.NewGuid();
        return new InventoryItem(id, productId, quantity, createdDate);
    }

    public void AdjustQuantity(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Quantity cannot be negative.", nameof(count));
        }

        Quantity += count;
        LastUpdatedUtc = DateTime.UtcNow;
    }

    public InventoryItem(Guid id, Guid productId, int quantity, DateTime lastUpdatedUtc)
    {
        Id = id;
        ProductId = productId;
        Quantity = quantity;
        LastUpdatedUtc = lastUpdatedUtc;
    }
}
