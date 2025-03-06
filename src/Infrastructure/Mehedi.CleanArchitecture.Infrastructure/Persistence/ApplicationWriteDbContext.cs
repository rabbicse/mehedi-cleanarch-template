namespace CleanArchitecture.Infrastructure.Persistence;

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Mehedi.Application.SharedKernel.Persistence;
using System.Reflection;
using CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using CleanArchitecture.Infrastructure.EfConfigurations;
using Mehedi.Core.SharedKernel;

/// <summary>
/// Represents the RDBMS database context for the application.
/// Initializes a new instance of the <see cref="ApplicationWriteDbContext"/> class.
/// </summary>
/// <param name="options"></param>
public class ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options) : DbContext(options), IWriteDbContext
{
    /// <summary>
    /// Gets or sets the set of customers in the database.
    /// </summary>
    public DbSet<Customer> AmbsReportsBackup => Set<Customer>();

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types exposed in <see cref="DbContext.Set{TEntity}"/> and from
    /// DbSet properties on the derived context. This is a no-op if there are no configurations to apply.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply entity configurations from the customer configuration
#pragma warning disable CA1062 // Validate arguments of public methods
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
#pragma warning restore CA1062 // Validate arguments of public methods

        // Apply entity configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Exclude BaseDomainEvent from being included in the DbContext
        modelBuilder.Ignore<BaseDomainEvent>();
        base.OnModelCreating(modelBuilder);
    }
}

