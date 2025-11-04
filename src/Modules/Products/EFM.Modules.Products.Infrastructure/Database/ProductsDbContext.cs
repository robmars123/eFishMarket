using EFM.Modules.Products.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace EFM.Modules.Products.Infrastructure.Database;

public sealed class ProductsDbContext(DbContextOptions<ProductsDbContext> options) : DbContext(options)//, IUnitOfWork
{
    private const string schema = "Products";
    internal DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(schema);
    }
}
