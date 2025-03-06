using CleanArchitecture.Domain.Aggregates.CustomerAggregate;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Queries;

public record GetAllCustomerQuery : IRequest<Result<IEnumerable<CustomerQueryModel>>>;
