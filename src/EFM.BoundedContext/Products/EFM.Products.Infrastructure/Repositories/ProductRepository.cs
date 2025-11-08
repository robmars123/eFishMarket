using Dapper;
using EFM.Products.Application.Abstractions.Database;
using EFM.Products.Application.Products.GetPagedProducts;
using EFM.Products.Application.Products.GetProductById;
using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Products.Infrastructure.Database;
using EFM.SharedKernel.Application.Results;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFM.Products.Infrastructure.Repositories;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductDbContext dbContext, IConnectionDbFactory connection)
        : base(dbContext, connection)
    {
    }

    public async Task AddProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await AddAsync(product, cancellationToken);
    }

    public async Task<GetProductByIdResponse> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        GetProductByIdResponse? product = await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.Id == id && !p.IsDeleted)
            .Select(p => new GetProductByIdResponse(p.Id, p.Name, p.UnitPrice))
            .FirstOrDefaultAsync(cancellationToken);

        return product;
    }

    public async Task<PagedResult<GetPagedProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_connection);
        await connection.OpenAsync(cancellationToken);

        string sql = """
                SELECT COUNT(*) 
                FROM Products.Product 
                WHERE IsDeleted = 0;

                SELECT Id, Name, UnitPrice, CreatedDate
                FROM Products.Product
                WHERE IsDeleted = 0
                ORDER BY CreatedDate desc
                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
                """;

        using SqlMapper.GridReader multi = await connection.QueryMultipleAsync(sql, new
        {
            Offset = (request.Page - 1) * request.PageSize,
            request.PageSize
        });

        int totalCount = await multi.ReadSingleAsync<int>();
        var products = (await multi.ReadAsync<Product>()).ToList();

        var responses = products
            .Select(p => new GetPagedProductsResponse(p.Id, p.Name, p.UnitPrice))
            .ToList();

        PagedResult<GetPagedProductsResponse> result = new PagedResult<GetPagedProductsResponse>(responses, totalCount);
        return result;
    }
}
