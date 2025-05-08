using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.DTOs;
using Mehedi.CleanArchitecture.Domain.ValueObjects;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Update;

public record UpdateCustomerCommand(Guid Id, string Name, PhoneNumber Phone): IRequest<Result<CustomerResponse>>;
