using CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.EfConfigurations;

/// <summary>
/// Source: https://github.com/dotnet/eShop/blob/main/src/Ordering.Infrastructure/OrderingContext.cs
/// https://github.com/dotnet/eShop/blob/main/src/Ordering.Infrastructure/EntityConfigurations/OrderEntityTypeConfiguration.cs
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer));

#pragma warning disable CA1062 // Validate arguments of public methods
        builder.Ignore(b => b!.DomainEvents);
#pragma warning restore CA1062 // Validate arguments of public methods

        builder.OwnsOne(o => o.PhoneNumber);
    }
}
