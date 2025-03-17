using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Delete;

public record DeleteCustomerCommand(Guid Id): IRequest<Result>;
