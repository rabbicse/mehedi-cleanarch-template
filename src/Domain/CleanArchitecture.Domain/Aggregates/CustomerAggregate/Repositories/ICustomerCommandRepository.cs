using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;

public interface ICustomerCommandRepository : ICommandRepository<Customer, Guid>
{
}
