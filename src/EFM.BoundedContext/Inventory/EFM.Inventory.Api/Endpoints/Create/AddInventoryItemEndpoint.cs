using EFM.Common.Application.Mediator;
using EFM.Inventory.Api.Models;
using EFM.Inventory.Application.InventoryItems.AddInventoryItem;
using Microsoft.AspNetCore.Http;

namespace EFM.Inventory.Api.Endpoints.Create;

public class AddInventoryItemEndpoint
{
    public static async Task<IResult> AddInventoryItemAsync(AddInventoryItemRequest request, IDispatcher dispatcher)
    {
        if (request == null)
        {
            return Results.BadRequest();
        }

        var command = new AddInventoryItemCommand(request.ProductId, request.Quantity);
        await dispatcher.Send(command);

        return Results.Created($"/api/inventoryItem", request);
    }
}
