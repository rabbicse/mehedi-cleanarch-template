using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Domain.Aggregates.CustomerAggregate;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Queries;

public record GetAllCustomerQuery : IRequest<Result<IEnumerable<CustomerQueryModel>>>;
