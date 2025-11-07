using EFM.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace EFM.Modules.Products.Infrastructure.Database;

public sealed class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }
    private const string schema = "Products";
    internal DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(schema);

        // Configure Product entity
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.UnitPrice)
                  .HasColumnType("decimal(18,4)");
        });

        modelBuilder.Entity<Product>().ToTable("Product");
    }
}
