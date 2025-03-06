using Mehedi.Core.SharedKernel;

namespace CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;

public interface ICustomerQueryRepository : IQueryRepository<CustomerQueryModel, Guid>
{
    Task<string> GetReportByToken(Guid token);
}
