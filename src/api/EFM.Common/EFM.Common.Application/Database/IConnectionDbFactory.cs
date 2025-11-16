namespace EFM.Common.Application.Database;

/// <summary>
/// Provides a mechanism to retrieve the connection string for a database.
/// </summary>
/// <remarks>This interface is typically used to abstract the retrieval of database connection strings, allowing
/// for flexibility in how connection strings are managed and provided.</remarks>
public interface IConnectionDbFactory
{
    string GetConnectionString();
}
