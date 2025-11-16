using Dapper;
using EFM.Common.Application.Database;
using EFM.Common.Application.Results;
using EFM.Common.Infrastructure.Repositories;
using EFM.Products.Application.Products.GetPagedProducts;
using EFM.Products.Application.Products.GetProductById;
using EFM.Products.Application.Repositories;
using EFM.Products.Domain.Products;
using EFM.Products.Infrastructure.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EFM.Products.Infrastructure.Repositories;
public class ReadOnlyProductRepository : BaseRepository<Product, ProductDbContext>, IReadOnlyProductRepository
{
    public ReadOnlyProductRepository(ProductDbContext dbContext, IConnectionDbFactory connection)
    : base(dbContext, connection)
    {
    }
    public async Task<GetProductByIdResponse> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        GetProductByIdResponse? product = await _dbContext.Products
            .AsNoTracking()
            .Where(p => p.Id == id && !p.IsDeleted)
            .Select(p => new GetProductByIdResponse(true, null, p.Id, p.Name, p.UnitPrice))
            .FirstOrDefaultAsync(cancellationToken);

        return product;
    }

    public async Task<PagedResponse<GetPagedProductsResponse>> GetProducts(GetPagedProductsQuery request, CancellationToken cancellationToken)
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

        PagedResponse<GetPagedProductsResponse> result = PagedResponse<GetPagedProductsResponse>.Success(responses, totalCount, request.Page, request.PageSize);
        return result;
    }
}
