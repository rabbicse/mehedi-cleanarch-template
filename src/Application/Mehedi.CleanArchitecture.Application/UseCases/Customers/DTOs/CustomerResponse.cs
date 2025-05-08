using Mehedi.CleanArchitecture.Domain.ValueObjects;
using Mehedi.Application.SharedKernel.Responses;

namespace Mehedi.CleanArchitecture.Application.UseCases.Customers.DTOs;


public record CustomerResponse(Guid Id, string Name, PhoneNumber? Phone) : IResponse;

