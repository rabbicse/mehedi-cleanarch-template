using CleanArchitecture.Application.UseCases.Customers.DTOs;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Update;

public record UpdateCustomerCommand(Guid id, string name): IRequest<Result<CustomerResponse>>;
