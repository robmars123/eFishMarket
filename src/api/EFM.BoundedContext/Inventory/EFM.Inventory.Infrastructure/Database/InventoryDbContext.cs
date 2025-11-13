using EFM.Common.Domain.Abstractions;
using EFM.Inventory.Domain.InventoryItems;
using Microsoft.EntityFrameworkCore;

namespace EFM.Inventory.Infrastructure.Database;

public sealed class InventoryDbContext : DbContext, IUnitOfWork
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }
    private const string schema = "InventoryItems";
    internal DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(schema);

        // Configure Product entity
        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("NEWID()"); // SQL Server generates new Guid automatically

            entity.Property(e => e.ProductId)
                  .IsRequired();
            entity.Property(e => e.Quantity)
                  .HasDefaultValue(0);
        });

        modelBuilder.Entity<InventoryItem>().ToTable("InventoryItem");
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
