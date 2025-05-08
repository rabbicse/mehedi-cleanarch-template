using Mehedi.CleanArchitecture.Domain.ValueObjects;
using MediatR;
using Mehedi.Application.SharedKernel.Responses;
using Mehedi.CleanArchitecture.Application.UseCases.Customers.DTOs;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.Commands.Create;

public record CreateCustomerCommand(string Name, PhoneNumber? phone): IRequest<Result<CustomerResponse>>;
