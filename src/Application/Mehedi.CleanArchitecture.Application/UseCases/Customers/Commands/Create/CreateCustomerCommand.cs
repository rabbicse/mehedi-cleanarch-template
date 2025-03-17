using CleanArchitecture.Application.UseCases.Customers.DTOs;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Create;

public record CreateCustomerCommand(string Name, PhoneNumber? phone): IRequest<Result<CustomerResponse>>;
