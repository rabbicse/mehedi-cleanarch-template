using Mehedi.Application.SharedKernel.Persistence;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;
using Mehedi.Write.RDBMS.Infrastructure.Abstractions.Repositories;

namespace Mehedi.CleanArchitecture.Infrastructure.Repositories;

public class CustomerCommandRepository(IWriteDbContext writeDbContext) : CommandRepository<Customer, Guid>(writeDbContext), ICustomerCommandRepository
{
}
