using EFM.Products.Application.Abstractions.Database;
using Microsoft.Extensions.Configuration;

namespace EFM.Products.Infrastructure.Database;
public class ConnectionDbFactory : IConnectionDbFactory
{
    private readonly string _connectionString;

    public ConnectionDbFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public string GetConnectionString()
    {
        return _connectionString;
    }
}
