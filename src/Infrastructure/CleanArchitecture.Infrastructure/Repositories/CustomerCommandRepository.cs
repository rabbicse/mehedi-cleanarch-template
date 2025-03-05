using CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using Mehedi.Application.SharedKernel.Persistence;
using Mehedi.Write.RDBMS.Infrastructure.Abstractions.Repositories;

namespace CleanArchitecture.Infrastructure.Repositories;

public class CustomerCommandRepository(IWriteDbContext writeDbContext) : CommandRepository<Customer, Guid>(writeDbContext), ICustomerCommandRepository
{
}
