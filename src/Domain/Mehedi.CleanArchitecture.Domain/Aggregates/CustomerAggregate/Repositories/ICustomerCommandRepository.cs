using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;

public interface ICustomerCommandRepository : ICommandRepository<Customer, Guid>;
