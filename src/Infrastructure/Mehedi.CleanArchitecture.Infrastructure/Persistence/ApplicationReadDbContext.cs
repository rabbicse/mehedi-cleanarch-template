﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationReadDbContext : IDisposable
{
    private readonly Lazy<IDbConnection?> _lazyConnection;

    public ApplicationReadDbContext(string? connectionString)
    {
        _lazyConnection = new Lazy<IDbConnection?>(() =>
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        });
    }

    public IDbConnection? Connection => _lazyConnection?.Value;

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~ApplicationReadDbContext() => Dispose(false);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (_lazyConnection.IsValueCreated && _lazyConnection.Value?.State != ConnectionState.Closed)
        {
            _lazyConnection.Value?.Close();
            _lazyConnection.Value?.Dispose();
        }

        _disposed = true;
    }

    #endregion
}


