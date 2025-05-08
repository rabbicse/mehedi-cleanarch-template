using Mehedi.Core.SharedKernel;

namespace Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate.Repositories;

public interface ICustomerQueryRepository : IQueryRepository<CustomerQueryModel, Guid>
{
    Task<string> GetReportByToken(Guid token);
}
