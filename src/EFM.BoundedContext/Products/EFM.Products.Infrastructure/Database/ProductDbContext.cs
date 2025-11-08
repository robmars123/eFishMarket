using EFM.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace EFM.Products.Infrastructure.Database;

public sealed class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
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
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .HasDefaultValueSql("NEWID()"); // SQL Server generates new Guid automatically

            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(e => e.UnitPrice)
                  .HasColumnType("decimal(18,4)");
        });

        modelBuilder.Entity<Product>().ToTable("Product");
    }
}
