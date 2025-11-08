using EFM.Products.Domain.Products;
using EFM.Products.Infrastructure.Database;
using EFM.Products.Application.Products.GetAllProducts;
using EFM.SharedKernel.Application.Results;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using EFM.Products.Application.Repositories;

namespace EFM.Products.Infrastructure.Repositories;
public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private readonly string _connectionString;
    public ProductRepository(ProductDbContext dbContext, IConfiguration configuration) : base(dbContext)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<PagedResult<GetAllProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        using var connection = new SqlConnection(_connectionString);
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
            .Select(p => new GetAllProductsResponse(p.Id, p.Name, p.UnitPrice))
            .ToList();

        PagedResult<GetAllProductsResponse> result = new PagedResult<GetAllProductsResponse>(responses, totalCount);
        return result;
    }
}
