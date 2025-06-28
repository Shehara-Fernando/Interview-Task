using Microsoft.Data.SqlClient;
using System;

namespace TaskManagement.Infrastructure.Data;

public class SqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection CreateConnection()
    {
        try
        {
            return new SqlConnection(_connectionString);
        }
        catch (TypeInitializationException ex) when (ex.InnerException is System.IO.FileNotFoundException fileNotFoundEx)
        {
            // This exception is commonly caused by missing assemblies (e.g., System.Security.Permissions)
            throw new InvalidOperationException(
                $"Failed to create SQL connection. Missing assembly: {fileNotFoundEx.FileName}. " +
                "Ensure all required NuGet packages are installed and referenced. " +
                "For .NET 6, make sure Microsoft.Data.SqlClient is at least version 4.0.0.",
                ex);
        }
    }
}
