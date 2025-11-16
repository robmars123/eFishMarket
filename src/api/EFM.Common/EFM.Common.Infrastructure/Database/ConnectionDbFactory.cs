using EFM.Common.Application.Database;
using Microsoft.Extensions.Configuration;

namespace EFM.Common.Infrastructure.Database;
/// <summary>
/// Provides a factory for retrieving the database connection string.
/// </summary>
/// <remarks>This class retrieves the connection string from the application's configuration settings. It is
/// designed to provide a consistent way to access the connection string for database operations.</remarks>
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
