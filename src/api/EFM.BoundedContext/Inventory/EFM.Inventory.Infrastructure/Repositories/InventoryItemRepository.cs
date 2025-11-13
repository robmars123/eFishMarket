using System.Threading;
using EFM.Common.Application.Database;
using EFM.Common.Infrastructure.Repositories;
using EFM.Inventory.Application.Abstractions.Repositories;
using EFM.Inventory.Domain.InventoryItems;
using EFM.Inventory.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EFM.Inventory.Infrastructure.Repositories;

public class InventoryItemRepository : BaseRepository<InventoryItem, InventoryDbContext>, IInventoryItemRepository
{
    public InventoryItemRepository(InventoryDbContext dbContext, IConnectionDbFactory connection)
        : base(dbContext, connection)
    {
    }

    public async Task AddInventoryItemAsync(InventoryItem item, CancellationToken cancellationToken)
    {
        await AddAsync(item, cancellationToken);
    }

    public async Task<InventoryItem?> GetInventoryByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.InventoryItems
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
