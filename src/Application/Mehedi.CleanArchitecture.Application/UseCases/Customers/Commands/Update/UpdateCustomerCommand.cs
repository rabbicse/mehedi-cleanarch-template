using CleanArchitecture.Application.UseCases.Customers.DTOs;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Update;

public record UpdateCustomerCommand(Guid Id, string Name, PhoneNumber Phone): IRequest<Result<CustomerResponse>>;
