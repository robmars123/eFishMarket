using EFM.Common.Application.Clock;
using EFM.Common.Application.Commands;
using EFM.Common.Domain.Abstractions;
using EFM.Inventory.Application.Abstractions.Repositories;
using EFM.Inventory.Domain.InventoryItems;

namespace EFM.Inventory.Application.InventoryItems.AddInventoryItem;
public class AddInventoryItemCommandHandler : ICommandHandler<AddInventoryItemCommand>
{
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUnitOfWork _unitOfWork;

    public AddInventoryItemCommandHandler(
        IInventoryItemRepository inventoryItemRepository, 
        IDateTimeProvider dateTimeProvider,
        IUnitOfWork unitOfWork)
    {
        _inventoryItemRepository = inventoryItemRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(AddInventoryItemCommand command, CancellationToken cancellationToken)
    {
        InventoryItem inventoryItem = InventoryItem.Create(command.ProductId, command.Quantity, _dateTimeProvider.UtcNow);

        await _inventoryItemRepository.AddInventoryItemAsync(inventoryItem, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //add event or notification if needed
    }
}
