using EFM.Common.Application.Database;
using Microsoft.Extensions.Configuration;

namespace EFM.Common.Infrastructure.Database;
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
